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


Setup
=====


Installation isn't 100% straight-forward. You will need to edit the
project .config files to point to your correct tools and servers. You
must also set the databases up.

You will need to checkout my C# bindings for nessus, nexpose, openvas,
and metasploit:


  git clone https://github.com/brandonprry/nexpose-sharp.git

  git clone https://github.com/brandonprry/nessus-sharp.git

  git clone https://github.com/brandonprry/openvas-sharp.git

  git clone https://github.com/brandonprry/metasploit-sharp.git


You will need to update your projects to point to these.


On your PGSql DB, create a database called autoassess and
autoassess_web.


Ensure you have the contrib package for pgsql installed because I rely
on the UUID contrib extension.


cat AutoAssess.Web.API/Database/AutoAssess_Service/Initial.sql | psql -h
127.0.0.1 -U postgres

cat AutoAsses.Web.API/Database/AutoAssess_Service/SeedService.sql | psql
-h 127.0.0.1 -U postgres

cat AutoAssess.Web.API/Database/AutoAssess_Web/Initial.sql | psql -h
127.0.0.1 -U postgres


Once you have created and seeded the db, you will nee dto extract two
values from it and update you web.config and app.config for Web and
Service. You need to select * from "user"; in autoassess_service and
grab the clientID and userID. Update these values in your configs with
the values in the database.

Web relies on the API, and an external state server
(start_state_server), so these must be started before browsing the web
UI.


