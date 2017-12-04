EXEC sp_MSForEachTable 'DELETE FROM ?';
exec sp_MSforeachtable @command1 = 'DBCC CHECKIDENT(''?'', RESEED, 0)';