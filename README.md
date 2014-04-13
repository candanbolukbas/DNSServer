DNSServer
=========

Custom DNS Server

This is a conditional DNS server with an XML file named **records.xml** that defines conditions. e.g.

<pre><code>
&lt;?xml version="1.0" encoding="utf-8"?&gt;<enter>
&lt;Records&gt;
	&lt;Record&gt;
		&lt;RecordType&gt;A&lt;/RecordType&gt;
		&lt;Name&gt;twitter.com&lt;/Name&gt;
		&lt;Address&gt;192.168.0.104&lt;/Address&gt;
		&lt;TimeToLive&gt;10&lt;/TimeToLive&gt;
	&lt;/Record&gt;
&lt;/Records&gt;
</code></pre>
