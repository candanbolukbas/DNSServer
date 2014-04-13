using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using ARSoft.Tools.Net.Dns;
using System.IO;

namespace DNSResolver
{
    public partial class MainForm : Form
    {
        bool isDnsServerRunning = false;
        DnsServer server;
        public MainForm()
        {
            InitializeComponent();
            WriteToXML();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                if (isDnsServerRunning)
                {
                    Application.Exit();
                    isDnsServerRunning = false;
                    server.Stop();
                    btn_start.BackColor = System.Drawing.Color.DarkRed;
                    btn_start.Text = "Start DNS Server";
                    tbxResult.AppendText("Server stopped successfully.\n");
                }
                else
                {
                    server = new DnsServer(IPAddress.Any, 100, 100, ProcessQuery);
                    server.ExceptionThrown += server_ExceptionThrown;
                    server.InvalidSignedMessageReceived += server_InvalidSignedMessageReceived;
                    server.Start();
                    isDnsServerRunning = true;
                    btn_start.BackColor = System.Drawing.Color.DarkGreen;
                    btn_start.Text = "Stop DNS Server";
                    tbxResult.AppendText("Server started successfully.\n");
                }
            }
            catch (Exception ex)
            {
                tbxResult.AppendText("ERROR #1: " + ex.Message + "\n");
            }
        }

        void server_InvalidSignedMessageReceived(object sender, InvalidSignedMessageEventArgs e)
        {
        }

        void server_ExceptionThrown(object sender, ExceptionEventArgs e)
        {
        }
        private DnsMessageBase ProcessQuery(DnsMessageBase message, IPAddress clientAddress, ProtocolType protocol)
        {
            message.IsQuery = false;

            DnsMessage query = message as DnsMessage;

            if ((query != null) && (query.Questions.Count == 1))
            {
                // send query to upstream server
                DnsQuestion question = query.Questions[0];
                DnsMessage answer;
                List<ARecord> predefinedRecords = ReadItems();
                List<string> clients = ReadClients();

                if (predefinedRecords != null && predefinedRecords.Select(r => r.Name).Contains(question.Name) && clients != null && clients.Contains(clientAddress.ToString()))
                {
                    answer = new DnsMessage();
                    answer.AnswerRecords.Add(predefinedRecords.First(r => r.Name == question.Name));
                }
                else
                {
                    List<IPAddress> dnsServers = new List<IPAddress> { IPAddress.Parse("8.8.8.8"), IPAddress.Parse("8.8.4.4") };
                    DnsClient client = new DnsClient(dnsServers, 30);

                    answer = client.Resolve(question.Name, question.RecordType, question.RecordClass);
                }

                // if got an answer, copy it to the message sent to the client
                if (answer != null)
                {
                    foreach (DnsRecordBase record in (answer.AnswerRecords))
                    {
                        query.AnswerRecords.Add(record);
                    }
                    foreach (DnsRecordBase record in (answer.AdditionalRecords))
                    {
                        query.AnswerRecords.Add(record);
                    }

                    query.ReturnCode = ReturnCode.NoError;
                    return query;
                }
            }

            // Not a valid query or upstream server did not answer correct
            message.ReturnCode = ReturnCode.ServerFailure;
            return message;
        }

        private void WriteToXML()
        {
            if (System.IO.File.Exists("records.xml"))
                return;

            try
            {
                ARecord[] records = new ARecord[4];
                records[0] = new ARecord("twitter.com", 10, IPAddress.Parse("192.168.0.104"));
                records[1] = new ARecord("www.facebook.com", 10, IPAddress.Parse("192.168.0.105"));
                records[2] = new ARecord("accounts.google.com", 10, IPAddress.Parse("192.168.0.106"));
                records[3] = new ARecord("mail.yandex.com", 10, IPAddress.Parse("192.168.0.107"));

                using (XmlWriter writer = XmlWriter.Create("records.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Records");

                    foreach (ARecord r in records)
                    {
                        writer.WriteStartElement("Record");

                        writer.WriteElementString("RecordType", r.RecordType.ToString());
                        writer.WriteElementString("Name", r.Name);
                        writer.WriteElementString("Address", r.Address.ToString());
                        writer.WriteElementString("TimeToLive", r.TimeToLive.ToString());

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            catch
            {
            }
        }

        private List<ARecord> ReadItems()
        {
            var items = XDocument.Load("records.xml").Root.Elements().Select(y => y.Elements().ToDictionary(x => x.Name, x => x.Value)).ToArray();
            List<ARecord> records = new List<ARecord>();

            foreach (var item in items)
            {
                records.Add(new ARecord(item["Name"], int.Parse(item["TimeToLive"]), IPAddress.Parse(item["Address"])));
            }

            return records;
        }
        private List<string> ReadClients()
        {
            if (File.Exists("clients.txt"))
                return File.ReadAllLines("clients.txt").ToList();
            else
                return null;
        }
    }
}
