rising_sun
==========

This has been the ruin of many a poor boy.




This is essentially my automated security playground. Beware.


Current tools supported to certain extents are nmap, nikto, smbclient,
onesixtyone, Metasploit/Pro, Nessus, OpenVAS, Nexpose, Wapiti, DSXS,
SQLMap, and SSLScan just to name a few. Many more are expected.


Currently the database schemas are stored in
AutoAssess.Web.API/Database/.


We are split into three groups. A Web UI, an API, and a service which
does the actual tool automation.


The web UI currently does not show all the data we store.


The service is intelligent and knows what tools can feed into which
other tools (wapiti -> sqlmap, wapiti -> dsxs,
nessus/nexpose/openvas/wapiti -> metasploit, etc...).


The service also knows which tools are appropriate for which services,
it is not based on ports.

Using FluentNHibernate (and thus NHibernate) and Postgresql, development has been solely on monodevelop/vim on various linuxes.


I use my nessus-sharp, metasploit-sharp, openvas-sharp, and
nexpose-sharp libs to automate the respective tools. clam-sharp will fit in here soon.


In order to allow metasploit to remotely absorb reports, I mounted the
/tmp of the remote machine to a local directory using sshfs. This is 
hardcoded atm.


I keep documentation, but it isn't great. See en_html/


This will never be finished or have real releases, git is it.


Have fun. There is probably XSS everywhere atm. I have been lazy. :)


Also, you are going to see a lot of crappy code (mainly in the UI) :/

Usually my testbed is a vulnerable FreeNAS release, an altered (TWiki
removed) Metasploitable2, avulnerable Windows XP machine, and BadStore, 
though it can depend on what I am testing.
