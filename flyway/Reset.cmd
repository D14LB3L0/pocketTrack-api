@echo off
flyway -configFiles=flyway.conf clean
flyway -configFiles=flyway.conf migrate
pause
