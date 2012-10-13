rising_sun
==========

This has been the ruin of many a poor boy.




This is essentially my automated security playground. Beware.


Current tools supported to certain extents are nmap, nikto, smbclient,
onesixtyone, Metasploit/Pro, Nessus, OpenVAS, Nexpose, Wapiti, DSXS,
SQLMap, just to name a few. Many more are expected.


Currently the database schemas are stored in
AutoAssess.Web.API/Database/.


We are split into three groups. A Web UI, an API, and a service which
does the actual tool automation.


The web UI currently does not show all the data we store.


The service is intelligent and knows what tools can feed into which
other tools (wapiti -> sqlmap, wapiti -> dsxs,
nessus/nexpose/openvas/wapiti -> metasploit, etc...).


Using FluentNHibernate (and thus NHibernate) and Postgresql, development has been solely on monodevelop/vim on various linuxes.


I use my nessus-sharp, metasploit-sharp, openvas-sharp, and
nexpose-sharp libs to automate the respective tools. clam-sharp will fit in here soon.


I keep documentation, but it isn't great. See en_html/


This will never be finished or have real releases, git is it.

Have fun. :)
