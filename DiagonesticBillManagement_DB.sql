USE [master]
GO
/****** Object:  Database [DiagonesticBillManagement_DB]    Script Date: 8/12/2016 3:20:36 AM ******/
CREATE DATABASE [DiagonesticBillManagement_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DiagonesticBillManagement_DB', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DiagonesticBillManagement_DB.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DiagonesticBillManagement_DB_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DiagonesticBillManagement_DB_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DiagonesticBillManagement_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET  MULTI_USER 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DiagonesticBillManagement_DB]
GO
/****** Object:  Table [dbo].[PatientBillPayment]    Script Date: 8/12/2016 3:20:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientBillPayment](
	[BillNo] [int] IDENTITY(1111,1) NOT NULL,
	[TotalAmount] [money] NOT NULL,
	[PaidAmount] [money] NULL CONSTRAINT [DF__PatientBi__PaidA__6AEFE058]  DEFAULT ((0)),
	[DueAmount]  AS ([TotalAmount]-[PaidAmount]),
	[MobileNo] [char](15) NULL,
	[BillDate] [date] NULL CONSTRAINT [DF__PatientBi__BillD__6CD828CA]  DEFAULT (getdate()),
 CONSTRAINT [PK__PatientB__11F2841997E38743] PRIMARY KEY CLUSTERED 
(
	[BillNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatientInformation]    Script Date: 8/12/2016 3:20:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientInformation](
	[PatientId] [int] IDENTITY(1111,1) NOT NULL,
	[PatientName] [varchar](30) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[MobileNo] [char](15) NOT NULL,
 CONSTRAINT [PK__PatientI__D6D73A876DAF7008] PRIMARY KEY CLUSTERED 
(
	[MobileNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatientTestRequest]    Script Date: 8/12/2016 3:20:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientTestRequest](
	[TestId] [int] NOT NULL,
	[MobileNo] [char](15) NULL,
	[TestDate] [date] NULL CONSTRAINT [DF__PatientTe__TestD__681373AD]  DEFAULT (getdate())
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestDetails]    Script Date: 8/12/2016 3:20:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestDetails](
	[TestId] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [varchar](255) NOT NULL,
	[Fee] [money] NOT NULL,
	[TypeID] [int] NOT NULL,
 CONSTRAINT [PK__TestDeta__8CC331609BB3C41B] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__TestDeta__2AF07A7DFF547D57] UNIQUE NONCLUSTERED 
(
	[TestName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestType]    Script Date: 8/12/2016 3:20:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestType](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](255) NOT NULL,
 CONSTRAINT [PK__TestType__516F03955E131C45] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__TestType__D4E7DFA88654CF15] UNIQUE NONCLUSTERED 
(
	[TypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[PatientBillPayment]  WITH CHECK ADD  CONSTRAINT [FK__PatientBi__Mobil__6BE40491] FOREIGN KEY([MobileNo])
REFERENCES [dbo].[PatientInformation] ([MobileNo])
GO
ALTER TABLE [dbo].[PatientBillPayment] CHECK CONSTRAINT [FK__PatientBi__Mobil__6BE40491]
GO
ALTER TABLE [dbo].[PatientTestRequest]  WITH CHECK ADD  CONSTRAINT [FK__PatientTe__Mobil__671F4F74] FOREIGN KEY([MobileNo])
REFERENCES [dbo].[PatientInformation] ([MobileNo])
GO
ALTER TABLE [dbo].[PatientTestRequest] CHECK CONSTRAINT [FK__PatientTe__Mobil__671F4F74]
GO
ALTER TABLE [dbo].[PatientTestRequest]  WITH CHECK ADD  CONSTRAINT [FK__PatientTe__TestI__662B2B3B] FOREIGN KEY([TestId])
REFERENCES [dbo].[TestDetails] ([TestId])
GO
ALTER TABLE [dbo].[PatientTestRequest] CHECK CONSTRAINT [FK__PatientTe__TestI__662B2B3B]
GO
ALTER TABLE [dbo].[TestDetails]  WITH CHECK ADD  CONSTRAINT [FK__TestDetai__TypeI__145C0A3F] FOREIGN KEY([TypeID])
REFERENCES [dbo].[TestType] ([TypeID])
GO
ALTER TABLE [dbo].[TestDetails] CHECK CONSTRAINT [FK__TestDetai__TypeI__145C0A3F]
GO
/****** Object:  StoredProcedure [dbo].[spInsertPatientTest]    Script Date: 8/12/2016 3:20:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spInsertPatientTest]
@TestName nvarchar(255),
@ContactNumber char(15)
as
begin
insert into PatientTestRequest (TestId,MobileNo) values 
((select TestId from TestDetails where TestName =@TestName),@ContactNumber)
end
GO
/****** Object:  StoredProcedure [dbo].[spPatientRequestTests]    Script Date: 8/12/2016 3:20:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[spPatientRequestTests]
@bilNo int
as
begin
select tD.TestName, tD.Fee from TestDetails tD join PatientTestRequest ptR on tD.TestId = ptR.TestId
join PatientBillPayment pBP on ptR.MobileNo = pBP.MobileNo where pBP.BillNo= @bilNo
end
GO
/****** Object:  StoredProcedure [dbo].[spTestWiseReport]    Script Date: 8/12/2016 3:20:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spTestWiseReport]
@fromDate date,
@toDate date
as
begin
select tD.TestName, COUNT(pTR.TestId) as TotalTest, SUM(tD.Fee) as TotalAmount
 from PatientTestRequest pTR join TestDetails tD on pTR.TestId = tD.TestId
where pTR.TestDate between @fromDate and @toDate
Group By tD.TestName
end
GO
/****** Object:  StoredProcedure [dbo].[spTypeWiseReport]    Script Date: 8/12/2016 3:20:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spTypeWiseReport]
@fromDate date,
@toDate date
as
begin
select tT.TypeName, COUNT(pTR.TestId) as TotalCount, SUM(tD.Fee) as TotalAmount
from TestType tT join TestDetails tD on tT.TypeID= tD.TypeID
join PatientTestRequest pTR on tD.TestId = pTR.TestId
where pTR.TestDate between @fromDate and @toDate
Group by tT.TypeName
end
GO
/****** Object:  StoredProcedure [dbo].[spUnpaidBillReport]    Script Date: 8/12/2016 3:20:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUnpaidBillReport]
@fromDate date,
@toDate date
as
begin
select pBP.BillNo,pBP.MobileNo, pIN.PatientName, pBP.DueAmount
from PatientBillPayment pBP join PatientInformation pIN on pBP.MobileNo = pIN.MobileNo
where pBP.BillDate between @fromDate and @toDate
end
GO
/****** Object:  StoredProcedure [dbo].[spUpdatePatientBillInfo]    Script Date: 8/12/2016 3:20:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUpdatePatientBillInfo]
@paidAmount money,
@billNo int
as
begin
Update PatientBillPayment set PaidAmount=PaidAmount+ @paidAmount where BillNo=@billNo
end
GO
USE [master]
GO
ALTER DATABASE [DiagonesticBillManagement_DB] SET  READ_WRITE 
GO
