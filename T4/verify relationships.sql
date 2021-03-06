SELECT        ParentProperties.Id AS ParentPropertyId, ChildProperties.Id AS ChildPropertyId, 2 AS RelationshipTypeId, ParentEntities.Name AS ParentEntity, ParentProperties.PropertyName AS ParentProperty, 
                         ChildEntities.Name AS ChildEntity, ChildProperties.PropertyName AS ChildProperty
FROM            AmoebaDB.dbo.Entities AS ParentEntities INNER JOIN
                         AmoebaDB.dbo.EntityProperties AS ParentProperties ON ParentEntities.Id = ParentProperties.EntityId INNER JOIN
                         AmoebaDB.dbo.ApplicationEntities ON ParentEntities.Id = AmoebaDB.dbo.ApplicationEntities.EntityId INNER JOIN
                         AmoebaDB.dbo.Entities AS ChildEntities INNER JOIN
                             (SELECT        KEY_COLUMN_USAGE_1.TABLE_NAME AS ParentTable, KEY_COLUMN_USAGE_1.COLUMN_NAME AS ParentColumn, 
                                                         INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.TABLE_NAME AS ChildTable, INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.COLUMN_NAME AS ChildColumn
                               FROM            INFORMATION_SCHEMA.CONSTRAINT_TABLE_USAGE INNER JOIN
                                                         INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS ON 
                                                         INFORMATION_SCHEMA.CONSTRAINT_TABLE_USAGE.CONSTRAINT_NAME = INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS.CONSTRAINT_NAME INNER JOIN
                                                         INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KEY_COLUMN_USAGE_1 ON 
                                                         INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS.UNIQUE_CONSTRAINT_NAME = KEY_COLUMN_USAGE_1.CONSTRAINT_NAME INNER JOIN
                                                         INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ON 
                                                         INFORMATION_SCHEMA.CONSTRAINT_TABLE_USAGE.CONSTRAINT_NAME = INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.CONSTRAINT_NAME) AS RelView ON 
                         ChildEntities.EntitySetName = RelView.ChildTable INNER JOIN
                         AmoebaDB.dbo.EntityProperties AS ChildProperties ON RelView.ChildColumn = ChildProperties.PropertyName AND ChildEntities.Id = ChildProperties.EntityId INNER JOIN
                         AmoebaDB.dbo.ApplicationEntities AS ApplicationEntities_1 ON ChildEntities.Id = ApplicationEntities_1.EntityId ON ParentProperties.PropertyName = RelView.ParentColumn AND 
                         ParentEntities.EntitySetName = RelView.ParentTable
WHERE        (AmoebaDB.dbo.ApplicationEntities.ApplicationId = 2) AND (ApplicationEntities_1.ApplicationId = 2) AND (ParentEntities.Name in ('Addresses', 'Exams')) OR
                         (ChildEntities.Name in ('Addresses', 'Exams'))

select * from AmoebaDB.dbo.RelationshipView where ChildEntity in( 'Addresses', 'Exams') or ParentEntity in ('Addresses', 'Exams')