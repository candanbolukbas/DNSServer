DNSServer
=========

Custom DNS Server

This is a conditional DNS server with an XML file named records.xml that defines conditions. e.g.

<?xml version="1.0" encoding="utf-8"?>
<Records>
	<Record>
		<RecordType>A</RecordType>
		<Name>twitter.com</Name>
		<Address>192.168.0.104</Address>
		<TimeToLive>10</TimeToLive>
	</Record>
</Records>
