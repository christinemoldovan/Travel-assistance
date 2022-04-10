SET DATEFORMAT dmy
use master
go
if exists (select * from sys.databases where name='Turism')
	begin
		alter database Turism set single_user 
			with rollback immediate
		drop database Turism
	end
go
create database Turism
go
alter authorization on database::Turism to sa
go
use Turism
go
CREATE TABLE [dbo].[Cazari] (
    [Cazare_id]     INT        IDENTITY (1, 1) NOT NULL,
    [Destinatie_id] INT        NOT NULL,
    [Data_Start]    DATE       NOT NULL,
    [Data_Stop]     DATE       NOT NULL,
    [Pret]          FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([Cazare_id] ASC),
    CONSTRAINT [FK_Cazari_ToTable] FOREIGN KEY ([Destinatie_id]) REFERENCES [dbo].[Destinatii] ([Destinatie_id])
);
CREATE TABLE [dbo].[Destinatii] (
    [Destinatie_id]  INT   IDENTITY (1, 1) NOT NULL,
    [NumeDestinatie] TEXT  NOT NULL,
    [Imagine]        IMAGE NULL,
    PRIMARY KEY CLUSTERED ([Destinatie_id] ASC)
);
CREATE TABLE [dbo].[Planificari] (
    [Plan_id]       INT  IDENTITY (1, 1) NOT NULL,
    [User_id]       INT  NOT NULL,
    [Destinatie_id] INT  NOT NULL,
    [Zbor_id] INT NOT NULL,
    [Cazare_id] INT NOT NULL,
    [Data_Start]    DATE NOT NULL,
    [Data_Stop]     DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([Plan_id] ASC),
    CONSTRAINT [FK_Planificari_Destinatii] FOREIGN KEY ([Destinatie_id]) REFERENCES [dbo].[Destinatii] ([Destinatie_id]),
    CONSTRAINT [FK_Planificari_Users] FOREIGN KEY ([User_id]) REFERENCES [dbo].[Users] ([User_id]),
    CONSTRAINT [FK_Planificari_Zboruri] FOREIGN KEY ([Zbor_id]) REFERENCES [dbo].[Zboruri]([Zbor_id]),
    CONSTRAINT [FK_Planificari_Cazari] FOREIGN KEY ([Cazare_id]) REFERENCES [dbo].[Cazari]([Cazare_id])
     
);
CREATE TABLE [dbo].[Users] (
    [User_id]   INT          IDENTITY (1, 1) NOT NULL,
    [UserName]  VARCHAR (50) NOT NULL,
    [Password]  VARCHAR (50) NOT NULL,
    [FirstName] TEXT         NULL,
    [LastName]  TEXT         NULL,
    PRIMARY KEY CLUSTERED ([User_id] ASC)
);
CREATE TABLE [dbo].[Zboruri] (
    [Zbor_id]       INT  IDENTITY (1, 1) NOT NULL,
    [Destinatie_id] INT  NOT NULL,
    [Data_Start]    DATE NOT NULL,
    [Data_Stop]     DATE NOT NULL,
    [Detalii]       TEXT NOT NULL,
    [Pret]          INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([Zbor_id] ASC),
    CONSTRAINT [FK_Zboruri_Destinatii] FOREIGN KEY ([Destinatie_id]) REFERENCES [dbo].[Destinatii] ([Destinatie_id])
);

GO
INSERT INTO Cazari(Cazare_id,Destinatie_id,Data_Start,Data_Stop,Pret ) VALUES
(1,1,5/1/2021,5/10/2021,10)
,(2,2,5/30/2021,6/3/2021,15)
,(3,3,7/2/2021,7/10/2021,20)
,(4,4,1/1/2021,1/10/2021,12)
,(5,5,2/10/2021,2/20/2021,17)
,(6,6,5/12/2021,5/17/2021,30)
GO
INSERT INTO Destinatii(Destinatie_id,NumeDestinatie,Imagine) VALUES
(1,Cairo,NULL)
,(2,Barcelona,NULL)
,(3,Amsterdam, NULL)
,(4,Paris,NULL)
,(5,Londra,NULL)
,(6,Viena, NULL)
,(7,Berlin,NULL)
,(8,Bucharest,NULL)
GO
INSERT INTO Planificari(Plan_id,User_id,Destinatie_id,Zbor_id,Cazare_id,Data_start,Data_stop) VALUES
(1,1,1,1,1,5/1/2023,5/10/2023)
,(2,5,2,2,2,5/30/2023,6/3/2023)
,(3,1,3,3,3,37/2/2023,7/10/2023)
,(4,7,6,6,6,5/12/2023,5/17/2023)
GO 
INSERT INTO Users(User_id,UserName,Password,FirstName,LastName) VALUES
(1,a,a,a,a)
,(2,abc,abc,abc,abc)
,(3,tt,tt,tt,tt)
,(4,b,b,b,b)
,(5,c,c,c,c)
,(6,d,d,d,d)
,(7,e,e,e,e)
GO
INSERT INTO Zboruri(Zbor_id,Destinatie_id,Data_Start,Data_Stop,Detalii,Pret) VALUES
(1,1,5/1/2023,5/10/2023,'Cluj-Napoca International Airport',50)
,(2,2,5/30/2023,6/3/2023,'Henri Coanda International Airport',20)
,(3,3,7/2/2022,7/10/2023,'Sibiu International Airport',75)
,(4,4,1/1/2022,1/10/2023,'Cluj-Napoca International Airport',25)
,(5,5,2/10/2023,2/20/2023,'Cluj-Napoca International Airport',40)
,(6,6,5/12/2023,5/17/2023,'Traian Vuia International Airport',38)
,(7,7,4/10/2023,4/15/2023,'Sibiu International Airport',62)
,(8,8,5/12/2023,5/17/2023,'Traian Vuia International Airport',44)