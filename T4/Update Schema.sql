UPDATE       AmoebaDB.dbo.Entities
set schemaname = 'dbo'


UPDATE       AmoebaDB.dbo.Entities
SET                SchemaName = INFORMATION_SCHEMA.TABLES.TABLE_SCHEMA
FROM            INFORMATION_SCHEMA.TABLES INNER JOIN
                         AmoebaDB.dbo.Entities ON INFORMATION_SCHEMA.TABLES.TABLE_NAME = AmoebaDB.dbo.Entities.EntitySetName
WHERE        (INFORMATION_SCHEMA.TABLES.TABLE_TYPE = 'BASE TABLE')