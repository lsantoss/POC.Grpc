USE [POC_Grpc] 

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