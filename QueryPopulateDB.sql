GO
INSERT INTO Destinatii(NumeDestinatie,Imagine) VALUES
('Cairo','cairo.jpg')
,('Barcelona','barcelona.jpg')
,('Amsterdam', 'amsterdam.jpg')
,('Paris','paris.jpg')
,('London','london.jpg')
,('Vienna', 'vienna.jpg')
,('Berlin','berlin.jpg')
,('Bucharest','bucharest.jpg')

GO
INSERT INTO Cazari(Destinatie_id,Data_Start,Data_Stop,Pret) VALUES
(1,'5-1-2021','5-10-2021',10)
,(2,'5-30-2021','6-3-2021',15)
,(3,'7-2-2021','7-10-2021',20)
,(4,'1-1-2021','1-10-2021',12)
,(5,'2-10-2021','2-20-2021',17)
,(6,'5-12-2021','5-17-2021',30)


GO
INSERT INTO Zboruri(Destinatie_id,Data_Start,Data_Stop,Detalii,Pret) VALUES
(1,'5/1/2023','5/10/2023','Cluj-Napoca International Airport',50)
,(2,'5/1/2023','6/3/2023','Henri Coanda International Airport',20)
,(3,'7/2/2022','7/10/2023','Sibiu International Airport',75)
,(4,'1/1/2022','1/10/2023','Cluj-Napoca International Airport',25)
,(5,'2/10/2023','2/20/2023','Cluj-Napoca International Airport',40)
,(6,'5/12/2023','5/17/2023','Traian Vuia International Airport',38)
,(7,'4/10/2023','4/15/2023','Sibiu International Airport',62)
,(8,'5/12/2023','5/17/2023','Traian Vuia International Airport',44)

GO
INSERT INTO Planificari(User_id,Destinatie_id,Zbor_id,Cazare_id,Data_start,Data_stop) VALUES
(1,1,1,1,'5/1/2023','5/10/2023')
,(5,2,2,2,'5/30/2023','6/3/2023')
,(1,3,3,3,'7/2/2023','7/10/2023')
,(7,6,6,6,'5/12/2023','5/17/2023')
GO 