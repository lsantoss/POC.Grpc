--====================================================================================================================================
--============================================== CREATE TABLE [dbo].[Customer] =======================================================
--====================================================================================================================================
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='Customer') 
BEGIN
    CREATE TABLE [dbo].[Customer] (
        [Id] [bigint] IDENTITY(1,1) NOT NULL,
        [Name] [nvarchar](100) NOT NULL,
        [Age] [tinyint] NOT NULL,
        [Active] [tinyint] NOT NULL,
        [CashBalanceFloat] [decimal](18, 2) NOT NULL,
        [CashBalanceDouble] [decimal](18, 2) NOT NULL,
        [CashBalanceDecimal] [decimal](18, 2) NOT NULL,
        CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
    (
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

--====================================================================================================================================
--=============================================== INSERT INTO [dbo].[Customer] =======================================================
--====================================================================================================================================

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='Customer') 
BEGIN
	INSERT INTO [dbo].[Customer] VALUES ('Lucas', 26, 1, 2502.35, 2502.35, 2502.35);
	INSERT INTO [dbo].[Customer] VALUES ('Steh', 29, 1, 7256.12, 7256.12, 7256.12);
	INSERT INTO [dbo].[Customer] VALUES ('Mattheus', 26, 0, 4895.11, 4895.11, 4895.11);
END