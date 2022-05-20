SELECT u.User_id as UserId, CONVERT(Varchar,d.NumeDestinatie) as Destination, CONVERT(Varchar,z.Detalii) as Departure, z.Pret as "Flight Price", c.Pret as "Accomodation Price", p.Data_Start as "From", p.Data_Stop as "Until" INTO #Dashboard
	FROM Users as u
	INNER JOIN Planificari as p ON u.User_id = p.User_id
	INNER JOIN Destinatii as d ON p.Destinatie_id = d.Destinatie_id
	INNER JOIN Cazari as c ON d.Destinatie_id = c.Destinatie_id
	INNER JOIN Zboruri as z ON d.Destinatie_id = z.Destinatie_id