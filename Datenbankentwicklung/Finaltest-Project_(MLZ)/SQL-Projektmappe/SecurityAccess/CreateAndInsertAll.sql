
-- Use SQLCMD Mode to run this file (<Menubar>->Query(Abfrage)->SQLCMD-Mode(SQLCMD-Modus)
-- and change path-var to correct folder-path
:setvar path "D:\OneDrive\HFU\Datenbankentwicklung 2\Projektmappen\SecurityAccess"
:r $(path)\CreateProcedures.sql
:r $(path)\CreateTables.sql
:r $(path)\InsertTestDefaults.sql