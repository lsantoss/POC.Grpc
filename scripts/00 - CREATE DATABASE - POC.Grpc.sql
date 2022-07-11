USE [master] 

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'POC.Grpc')
BEGIN
	CREATE DATABASE [POC.Grpc]
END