CREATE DATABASE sports

Select @@servername
SELECT * FROM SportsAssociationManager
GO
CREATE PROCEDURE createAllTables
AS    
    CREATE TABLE SystemUser
    (
        username VARCHAR(20) PRIMARY KEY,
        password VARCHAR(20)
    );

    CREATE TABLE SystemAdmin
    (
        aid INT PRIMARY KEY IDENTITY,
        name VARCHAR(20),
        username VARCHAR(20),
        FOREIGN KEY (username) REFERENCES SystemUser (username) ON DELETE CASCADE ON UPDATE CASCADE
    );

    CREATE TABLE SportsAssociationManager
    (
        amid INT PRIMARY KEY IDENTITY,
        name VARCHAR(20),
        username VARCHAR(20),
        FOREIGN KEY (username) REFERENCES SystemUser (username) ON DELETE CASCADE ON UPDATE CASCADE
    );

    CREATE TABLE Club
    (
        club_id INT PRIMARY KEY IDENTITY,
        name VARCHAR(20),
        location VARCHAR(20)
    );

    CREATE TABLE ClubRepresentative
    (
        crid INT PRIMARY KEY IDENTITY,
        name VARCHAR(20),
        username VARCHAR(20),
        club_id INT,
        FOREIGN KEY (username) REFERENCES SystemUser (username) ON DELETE CASCADE ON UPDATE CASCADE,
        FOREIGN KEY (club_id) REFERENCES Club (club_id) ON DELETE CASCADE ON UPDATE CASCADE
    );


    CREATE TABLE Stadium
    (
        sid INT PRIMARY KEY IDENTITY,
        name VARCHAR(20),
        location VARCHAR(20),
        capacity INT,
        status BIT
    );

    CREATE TABLE StadiumManager
    (
        smid INT PRIMARY KEY IDENTITY,
        name VARCHAR(20),
        stadium_id INT,
        username VARCHAR(20),
        FOREIGN KEY (username) REFERENCES SystemUser (username) ON DELETE CASCADE ON UPDATE CASCADE,
        FOREIGN KEY (stadium_id) REFERENCES Stadium (sid) ON DELETE CASCADE ON UPDATE CASCADE
    );

    CREATE TABLE Match
    (
        match_id INT PRIMARY KEY IDENTITY,
        start_time DATETIME,
        end_time DATETIME,
        host_club_id INT,
        guest_club_id INT,
        stadium_id INT,
        FOREIGN KEY (host_club_id) REFERENCES Club (club_id) ON DELETE CASCADE ON UPDATE CASCADE,
        FOREIGN KEY (guest_club_id) REFERENCES Club (club_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
        FOREIGN KEY (stadium_id) REFERENCES Stadium (sid) ON DELETE CASCADE ON UPDATE CASCADE 
    );

    CREATE TABLE HostRequest
    (
        hrid INT PRIMARY KEY IDENTITY,
        representative_id INT,
        manager_id INT,
        match_id INT,
        status VARCHAR(20),
        FOREIGN KEY (representative_id) REFERENCES ClubRepresentative (crid) ON DELETE NO ACTION ON UPDATE NO ACTION,
        FOREIGN KEY (manager_id) REFERENCES StadiumManager (smid) ON DELETE NO ACTION ON UPDATE NO ACTION,
        FOREIGN KEY (match_id) REFERENCES Match (match_id) ON DELETE CASCADE ON UPDATE CASCADE
    );

    CREATE TABLE Fan
    (
        national_id VARCHAR(20) PRIMARY KEY,
        name VARCHAR(20),
        birth_date DATETIME,
        address VARCHAR(20),
        phone_no VARCHAR(20),
        status BIT,
        username VARCHAR(20),
        FOREIGN KEY (username) REFERENCES SystemUser (username) ON DELETE CASCADE ON UPDATE CASCADE
    );

    CREATE TABLE Ticket
    (
        tid INT PRIMARY KEY IDENTITY,
        status BIT,
        match_id INT,
        FOREIGN KEY (match_id) REFERENCES Match (match_id) ON DELETE CASCADE ON UPDATE CASCADE
    );

     CREATE TABLE TicketBuyingTransactions
    (
        fan_nationalID VARCHAR(20),
        ticket_ID INT
        PRIMARY KEY(fan_nationalID, ticket_ID),
        FOREIGN KEY(fan_nationalID) REFERENCES Fan(national_id) ON DELETE CASCADE ON UPDATE CASCADE,
        FOREIGN KEY(ticket_ID) REFERENCES Ticket(tid) ON DELETE CASCADE ON UPDATE CASCADE
    );
GO

GO
CREATE PROCEDURE dropAllTables
AS
    DROP TABLE SystemAdmin;
    DROP TABLE SportsAssociationManager;
    DROP TABLE TicketBuyingTransactions
    DROP TABLE Fan
    DROP TABLE Ticket
    DROP TABLE HostRequest
    DROP TABLE Match
    DROP TABLE ClubRepresentative;
    DROP TABLE Club;
    DROP TABLE StadiumManager;
    DROP TABLE Stadium;
    DROP TABLE SystemUser;    
GO

GO
CREATE PROCEDURE clearAllTables
AS
    DELETE FROM SystemAdmin;
    DELETE FROM SportsAssociationManager;
    DELETE FROM TicketBuyingTransactions
    DELETE FROM Fan
    DELETE FROM Ticket
    DELETE FROM HostRequest
    DELETE FROM Match
    DELETE FROM ClubRepresentative;
    DELETE FROM Club;
    DELETE FROM StadiumManager;
    DELETE FROM Stadium;
    DELETE FROM SystemUser;
GO

GO
CREATE PROCEDURE dropAllProceduresFunctionsViews
AS
    DROP PROCEDURE dropAllTables;
    DROP PROCEDURE createAllTables;
    DROP PROCEDURE clearAllTables;
    DROP PROCEDURE addAssociationManager;
    DROP PROCEDURE addNewMatch;
    DROP PROCEDURE deleteMatch;
    DROP PROCEDURE deleteMatchesOnStadium;
    DROP PROCEDURE addClub;
    DROP PROCEDURE addTicket;
    DROP PROCEDURE deleteClub;
    DROP PROCEDURE addStadium;
    DROP PROCEDURE deleteStadium;
    DROP PROCEDURE blockFan;
    DROP PROCEDURE unblockFan;
    DROP PROCEDURE addRepresentative;
    DROP PROCEDURE addHostRequest;
    DROP PROCEDURE addStadiumManager;
    DROP PROCEDURE acceptRequest;
    DROP PROCEDURE rejectRequest;
    DROP PROCEDURE addFan;
    DROP PROCEDURE purchaseTicket;
    DROP PROCEDURE updateMatchHost;

    DROP FUNCTION viewAvailableStadiumsOn;
    DROP FUNCTION allUnassignedMatches;
    DROP FUNCTION allPendingRequests;
    DROP FUNCTION upcomingMatchesOfClub;
    DROP FUNCTION availableMatchesToAttend;
    DROP FUNCTION clubsNeverPlayed;
    DROP FUNCTION matchWithHighestAttendance;
    DROP FUNCTION matchesRankedByAttendance;
    DROP FUNCTION requestsFromClub;

    DROP VIEW matchesPerTeam;
    DROP VIEW clubsNeverMatched;
    DROP VIEW allAssocManagers;
    DROP VIEW allClubRepresentatives;
    DROP VIEW allStadiumManagers;
    DROP VIEW allFans;
    DROP VIEW allMatches;
    DROP VIEW allTickets;
    DROP VIEW allCLubs;
    DROP VIEW allStadiums;
    DROP VIEW allRequests;
    DROP VIEW clubsWithNoMatches;
GO

GO
CREATE VIEW allAssocManagers
AS
SELECT s.username, u.password, s.name
FROM SportsAssociationManager s INNER JOIN SystemUser u ON s.username = u.username;
GO

GO
CREATE VIEW allClubRepresentatives AS
SELECT cr.username, u.password, cr.name AS 'representative name', c.name AS 'Club name'
FROM SystemUser u INNER JOIN ClubRepresentative cr
ON u.username = cr.username
INNER JOIN Club c
ON cr.club_id = c.club_id;
GO

GO
CREATE VIEW allStadiumManagers AS
SELECT sm.username, u.password, sm.name AS 'Stadium manager name', s.name AS 'stadium name'
FROM SystemUser u INNER JOIN StadiumManager sm
ON u.username = sm.username
INNER JOIN Stadium s
ON sm.stadium_id = s.sid;
GO

GO
CREATE VIEW allFans AS
SELECT f.username, u.password, f.name, f.national_id, f.birth_date, f.status
FROM SystemUser u INNER JOIN Fan f
ON u.username = f.username;
GO


GO
CREATE VIEW allMatches AS
SELECT hc.name AS 'Host Club', gc.name AS 'Guest Club', m.start_time
FROM Club hc INNER JOIN Match m
ON hc.club_id = m.host_club_id
INNER JOIN Club gc
ON gc.club_id = m.guest_club_id;
GO


GO
CREATE VIEW allTickets AS
SELECT hc.name AS 'Host Club', gc.name AS 'Guest Club', s.name, m.start_time
FROM Club hc INNER JOIN Match m
ON hc.club_id = m.host_club_id
INNER JOIN Club gc
ON gc.club_id = m.guest_club_id
INNER JOIN Ticket t
ON t.match_id = m.match_id
INNER JOIN Stadium s
ON m.stadium_id = s.sid
GO

GO
CREATE VIEW allClubs AS
SELECT name, location
FROM Club;
GO

GO
CREATE VIEW allStadiums AS
SELECT name, location, capacity, status
FROM Stadium;
GO

GO
CREATE VIEW allRequests AS
SELECT cr.username AS 'Club representative username', sm.username AS 'Stadium Manager username', hr.status
FROM ClubRepresentative cr INNER JOIN HostRequest hr
ON cr.crid = hr.representative_id
INNER JOIN StadiumManager sm
ON hr.manager_id = sm.smid;
GO

SELECT * FROM SportsAssociationManager
EXEC createAllTables
--1 DONE
GO
CREATE PROCEDURE addAssociationManager
    @name VARCHAR(20),
    @username VARCHAR(20),
    @password VARCHAR(20)
AS
INSERT INTO SystemUser VALUES (@username, @password)

INSERT INTO SportsAssociationManager
VALUES(@name, @username)
GO


--2 DONE
GO
CREATE PROCEDURE addNewMatch
    @first_club VARCHAR(20),
    @second_club VARCHAR(20),
    @start_time DATETIME,
    @end_time DATETIME
AS
DECLARE @first_id INTEGER
SET @first_id =(SELECT C.club_id
                FROM club c
                WHERE c.name = @first_club
                )

DECLARE @second_id INTEGER
SET @second_id = (select c.club_id
                    FROM club c
                    WHERE c.name = @second_club
                    )

INSERT INTO Match
    (host_club_id, guest_club_id, start_time, end_time)
VALUES(@first_id, @second_id, @start_time, @end_time)
GO

--3 DONE
GO
CREATE VIEW clubsWithNoMatches
AS
    SELECT c.name
    FROM club C
    WHERE c.club_id <> (SELECT m.host_club_id
                        FROM Match m) AND c.club_id <> (SELECT m.guest_club_id
                                                        FROM Match m)
GO


--4 DONE
GO
CREATE PROCEDURE deleteMatch
    @first_club VARCHAR(20),
    @second_club VARCHAR(20)
AS
DECLARE @first_id INTEGER
SET @first_id = (select C.club_id
                FROM club c
                WHERE c.name = @first_club)

DECLARE @second_id INTEGER
SET @second_id = (select C.club_id
                  FROM club c
                  WHERE c.name = @second_club)


DELETE 
FROM match 
WHERE host_club_id = @first_id AND guest_club_id = @second_id
GO


--5 DONE
GO
CREATE PROCEDURE deleteMatchesOnStadium
    @stad_name VARCHAR(20)
AS
DELETE 
FROM Match 
WHERE match_id = (
    SELECT m.match_id
    FROM match m
    INNER JOIN stadium s ON m.stadium_id = s.sid
    WHERE (CAST(m.start_time AS DATE) < CAST(CURRENT_TIMESTAMP AS DATE)) AND s.name = @stad_name
)
GO


--6 DONE
GO
CREATE PROCEDURE addClub
    @name varchar(20),
    @location VARCHAR(20)
AS
INSERT INTO club
    (name, location)
VALUES
    (@name, @location)
GO

--7 DONE
GO
CREATE PROCEDURE addTicket
    @host_name VARCHAR(20),
    @guest_name VARCHAR(20),
    @start_time DATETIME
AS
DECLARE @first_id INTEGER
SET @first_id = (select C.club_id
                FROM club c
                WHERE c.name = @host_name)

DECLARE @second_id INTEGER
SET @second_id = (select C.club_id
                  FROM club c
                  WHERE c.name = @guest_name)


DECLARE @match_id INTEGER
SET @match_id = (SELECT m.match_id
                 FROM match M
                 WHERE m.host_club_id = @first_id AND m.guest_club_id = @second_id AND start_time = @start_time)

INSERT INTO ticket
    (match_id)
VALUES
    (@match_id)

UPDATE Ticket
SET status = 1
WHERE ticket.match_id = @match_id
GO



--8 DONE 
GO
CREATE PROCEDURE deleteClub
    @name VARCHAR(20)
AS
DELETE FROM Club 
WHERE name = @name
GO
 

--9 DONE 
GO
CREATE PROCEDURE addStadium
    @name VARCHAR(20),
    @LOCATION VARCHAR(20),
    @CAPACITY INT
AS
INSERT INTO Stadium
    (name, location, capacity, status)
VALUES
    (@name, @LOCATION, @CAPACITY, 1)
GO




--10 DONE
GO
CREATE PROCEDURE deleteStadium
    @name VARCHAR(20)
AS
DELETE FROM Stadium
WHERE stadium.name = @name
GO



--11 DONE
GO
CREATE PROCEDURE blockFan
    @nat_id VARCHAR(20)
AS
UPDATE fan
SET status = 0
WHERE fan.national_id = @nat_id
GO




--12 Done
GO
CREATE PROCEDURE unblockFan
    @nat_id VARCHAR(20)
AS
update Fan 
set status =1
where fan.national_id =@nat_id
GO

--13 DONE
GO
CREATE PROCEDURE addRepresentative
    @name VARCHAR(20),
    @club_name VARCHAR(20),
    @username VARCHAR(20),
    @pass VARCHAR(20)
AS
INSERT INTO SystemUser VALUES
        (@username,@pass);

DECLARE @club_id INT;

SELECT @club_id = club_id
FROM club 
WHERE
     @club_name= name;

INSERT INTO ClubRepresentative
    (name, club_id,username)
VALUES
    (@name, @club_id, @username)
GO




--14 Done
GO
CREATE FUNCTION [viewAvailableStadiumsOn]
(@X DATETIME) Returns @temp 
TABLE ( name varchar(20),
    location varchar(20),
    capacity varchar(20) ) AS
Begin
    INSERT INTO @temp
    SELECT s.name, s.location, s.capacity
    FROM Stadium s
        LEFT OUTER JOIN match m ON (s.sid = m.stadium_id)
    WHERE s.status = 1 AND (m.stadium_id IS NULL OR m.start_time <> @X)
    RETURN
END
GO


--15 done
GO
CREATE PROCEDURE addHostRequest
    @club_name VARCHAR(20),
    @stadium_name VARCHAR(20),
    @start_time DATETIME
AS
DECLARE @club_id INT;
SELECT @club_id = club_id
from club
WHERE name =@club_name;

DECLARE @stadium_id INT;
SELECT @stadium_id= stadium.sid 
FROM stadium
WHERE name = @stadium_name;

DECLARE @clubrepresentative_id INT;
DECLARE @stadium_manager_id INT;
SELECT @clubrepresentative_id= clubRepresentative.crid
FROM clubRepresentative
WHERE club_id= @club_id;

SELECT @stadium_manager_id= s.smid
FROM StadiumManager s
WHERE s.stadium_id = @stadium_id;


DECLARE @match_id INT;
SELECT @match_id=match_id
FROM Match
where start_time=@start_time AND Host_club_id=@club_id;
INSERT into hostrequest 
    (representative_id,manager_id,match_id,status) 
VALUES
    (@clubrepresentative_id ,@stadium_manager_id ,@match_id, 'unHandled')

GO


--16 Done

GO
CREATE FUNCTION [allUnassignedMatches]
(@X varchar(20)) Returns @temp 
TABLE (competing_club_name varchar(20),
    start_time DATETIME)AS
Begin
    INSERT INTO @temp
    SELECT c1.name , m.start_time
    FROM Club c INNER JOIN 
        Match m on (c.club_id=m.host_club_id) INNER JOIN club c1 on (c1.club_id =m.guest_club_id)
    WHERE m.stadium_id IS NULL and c.name = @x;
    RETURN
END
GO

--17 Done
GO
CREATE PROCEDURE addStadiumManager
    @name VARCHAR(20),
    @stadium_name VARCHAR(20),
    @username VARCHAR(20),
    @password VARCHAR(20)
AS
DECLARE @stadium_id INT;

SELECT @stadium_id= stadium.sid
FROM stadium 
WHERE @stadium_name= name;
INSERT INTO SystemUser VALUES
        (@username,@password);
        
INSERT INTO StadiumManager
    (name,stadium_id,username)
VALUES
    (@name, @stadium_id, @username)
GO


--18 
GO
CREATE FUNCTION [allPendingRequests]
(@X VARCHAR(20)) Returns @temp 
TABLE (CRname varchar(20),
    competingname varchar(20),
    statrttime DATETIME )AS
Begin
    INSERT INTO @temp
    SELECT cr.name, gc.name, m.start_time 
    FROM HostRequest h
        inner JOIN StadiumManager sm ON h.manager_id = sm.smid 
        INNER JOIN ClubRepresentative cr ON h.representative_id = cr.crid
        INNER JOIN Match m ON h.match_id = m.match_id
        INNER JOIN Club gc ON m.guest_club_id = gc.club_id
    WHERE sm.username = @X AND h.status = 'unHandled' 
    RETURN
END
GO


--19 done 
GO
CREATE PROCEDURE acceptRequest
    @stadium_manager_username VARCHAR(20),
    @hosting_club_name VARCHAR(20),
    @competing_club_name VARCHAR(20),
    @start_time DATETIME
AS
DECLARE @stadiumid INT;
DECLARE @stadium_manager_id INT;
SELECT @stadium_manager_id = smid, @stadiumid= stadium_id
from StadiumManager
WHERE username =@stadium_manager_username;

DECLARE @capacity INT;
SELECT @capacity= capacity
FROM Stadium
WHERE @stadiumid= sid;

DECLARE @cnt INT = 0;
WHILE @cnt < @capacity
BEGIN
   EXEC addTicket @hosting_club_name, @competing_club_name, @start_time;
   SET @cnt = @cnt + 1;
END;

DECLARE @club_host_id INT;
SELECT @club_host_id=club.club_id
FROM club 
WHERE name = @hosting_club_name;

DECLARE @club_competing_id INT;
SELECT @club_competing_id=club.club_id
FROM club 
WHERE name = @competing_club_name;

DECLARE @clubrepresentative_id INT;

SELECT @clubrepresentative_id= crid
FROM clubRepresentative
WHERE clubRepresentative.club_id= @club_host_id;


DECLARE @match_id INT;
SELECT @match_id=m.match_id
FROM Match  m
where m.start_time=@start_time AND m.host_club_id= @club_host_id
     and @club_competing_id= m.guest_club_id;

update HostRequest
set status = 'accepted'
WHERE match_id =@match_id and @clubrepresentative_id= representative_id 
    and @stadium_manager_id = manager_id;

DECLARE @stad_id INTEGER
SET @stad_id = (SELECT stadium_id
                FROM StadiumManager
                WHERE smid = @stadium_manager_id)

UPDATE Match
SET match.stadium_id = @stad_id
GO


--20 done
GO
CREATE PROCEDURE rejectRequest
    @stadium_manager_username VARCHAR(20),
    @hosting_club_name VARCHAR(20),
    @competing_club_name VARCHAR(20),
    @start_time DATETIME
AS
DECLARE @stadium_manager_id INT;
SELECT @stadium_manager_id = smid
from StadiumManager
WHERE username =@stadium_manager_username;

DECLARE @club_host_id INT;
SELECT @club_host_id=club.club_id
FROM club 
WHERE name = @hosting_club_name;

DECLARE @club_competing_id INT;
SELECT @club_competing_id=club.club_id
FROM club 
WHERE name = @competing_club_name;

DECLARE @clubrepresentative_id INT;

SELECT @clubrepresentative_id= crid
FROM clubRepresentative
WHERE clubRepresentative.club_id= @club_host_id;


DECLARE @match_id INT;
SELECT @match_id=m.match_id
FROM Match  m
where m.start_time=@start_time AND m.host_club_id= @club_host_id
     and @club_competing_id= m.guest_club_id;

update HostRequest
set status ='rejected'
WHERE match_id =@match_id and @clubrepresentative_id= representative_id 
    and @stadium_manager_id = manager_id;
GO


--21 Done
GO
CREATE PROCEDURE addFan
@fan_name VARCHAR(20),
@username VARCHAR(20),
@password VARCHAR(20),
@national_id VARCHAR(20),
@birthdate DATETIME,
@address varchar(20),
@phone_number INT

AS
INSERT INTO SystemUser VALUES(@username, @password)

INSERT INTO Fan
    (name, national_id, birth_date ,address, phone_no, username, status)
VALUES
    (@fan_name, @national_id, @birthdate,@address,@phone_number, @username, 1)
GO



--22 done
GO
CREATE FUNCTION [upcomingMatchesOfClub] 
(@club_name VARCHAR(20))
RETURNS @T TABLE(host VARCHAR(20), guest VARCHAR(20), start_time DATETIME, stad_name VARCHAR(20))
AS
BEGIN
INSERT INTO @T
SELECT c1.name, c2.name, m.start_time, s.name
FROM Match m
INNER JOIN Club C1 ON m.host_club_id = c1.club_id 
INNER JOIN Club C2 ON m.guest_club_id = c2.club_id
INNER JOIN Stadium S ON m.stadium_id = s.sid
WHERE m.start_time > CURRENT_TIMESTAMP AND c1.name = @club_name
UNION
SELECT c1.name, c2.name, m.start_time, s.name
FROM Match m
INNER JOIN Club C1 ON m.host_club_id = c1.club_id 
INNER JOIN Club C2 ON m.guest_club_id = c2.club_id
INNER JOIN Stadium S ON m.stadium_id = s.sid
WHERE m.start_time > CURRENT_TIMESTAMP AND c2.name = @club_name
RETURN
END
GO

--23 Done

GO
CREATE FUNCTION availableMatchesToAttend
(@date DATETIME)
RETURNS @tab TABLE (Host VARCHAR(20), Guest VARCHAR(20), Start_Time DATETIME, Stadium VARCHAR(20))
AS
BEGIN
    INSERT INTO @tab
    SELECT DISTINCT
        c1.name,
        c2.name,
        m.start_time,
        s.name
    FROM Match m
    INNER JOIN Ticket t
        ON t.match_id = m.match_id
    INNER JOIN Stadium s
        ON m.stadium_id = s.sid
    INNER JOIN Club c1
        ON c1.club_id = host_club_id
    INNER JOIN Club c2
        ON c2.club_id = guest_club_id    
    WHERE t.status = 1 AND @date < m.start_time AND CURRENT_TIMESTAMP < m.start_time
    ORDER BY m.start_time ASC
    RETURN
END
GO


--24 Done
GO
CREATE PROCEDURE purchaseTicket
    @fan_id VARCHAR(20),
    @host_name VARCHAR(20),
    @guest_name VARCHAR(20),
    @start_time DATETIME
AS  
    DECLARE @tid INT
    SET @tid = (SELECT TOP (1) t.tid
                FROM Ticket t
                INNER JOIN Match m
                    ON m.match_id = t.match_id
                INNER JOIN Club c1
                    ON c1.name = @host_name
                INNER JOIN Club c2 
                    ON c2.name = @guest_name
                INNER JOIN Fan f
                    ON f.national_id = @fan_id
                WHERE m.start_time = @start_time AND t.status = 1 AND f.status = 1)

    BEGIN TRY
        UPDATE Ticket
        SET status = 0
        WHERE tid = @tid
        INSERT INTO TicketBuyingTransactions
        VALUES (@fan_id, @tid)
    END TRY
    BEGIN CATCH
        PRINT 'Transaction could not be completed'
    END CATCH
GO


--25 Done
GO
CREATE PROCEDURE updateMatchHost
    @host_name VARCHAR(20),
    @guest_name VARCHAR(20),
    @date DATETIME
AS  
    UPDATE Match
    SET host_club_id = guest_club_id, guest_club_id = host_club_id
    WHERE match_id = (SELECT m.match_id
                FROM Match m
                INNER JOIN Club c1
                    ON c1.club_id = m.host_club_id
                INNER JOIN Club c2 
                    ON c2.club_id = m.guest_club_id
                WHERE m.start_time = @date AND c1.name = @host_name AND c2.name = @guest_name)
    DECLARE @hostID INT
    SET @hostID = (SELECT club_id
                   FROM Club
                   WHERE @host_name = name)
    DECLARE @crid INT 
    SET @crid = (SELECT cr.crid
                 FROM ClubRepresentative cr
                 WHERE @hostID = cr.club_id)
    DECLARE @match INT 
    SET @match = (SELECT m.match_id
                FROM Match m
                INNER JOIN Club c1
                    ON c1.club_id = m.host_club_id
                INNER JOIN Club c2 
                    ON c2.club_id = m.guest_club_id
                WHERE m.start_time = @date AND c1.name = @host_name AND c2.name = @guest_name)
    DELETE 
    FROM HostRequest 
    WHERE representative_id = @crid AND match_id = @match
GO

--26 Done
GO
CREATE VIEW matchesPerTeam
AS
SELECT c.name, count(m.match_id) AS numMatches
FROM Club c LEFT OUTER JOIN Match m
ON m.end_time < CURRENT_TIMESTAMP
AND (m.host_club_id = c.club_id OR m.guest_club_id = c.club_id)
GROUP BY c.name
GO


--27 Done

GO
CREATE VIEW clubsNeverMatched AS
    (SELECT c1.name Host, c2.name Guest
    FROM Club c1
    INNER JOIN Club c2 
        ON c1.name != c2.name)
    EXCEPT
    ((SELECT c1.name, c2.name
    FROM Match m
    INNER JOIN Club c1 
        ON m.host_club_id = c1.club_id 
    INNER JOIN Club c2 
        ON m.guest_club_id = c2.club_id)
    UNION 
    (SELECT c1.name, c2.name
    FROM Match m
    INNER JOIN Club c2 
        ON m.host_club_id = c2.club_id 
    INNER JOIN Club c1 
        ON m.guest_club_id = c1.club_id))
GO

--28 Done

GO
CREATE FUNCTION [clubsNeverPlayed]
(@cname VARCHAR(20)) 
Returns @tab TABLE (Club VARCHAR(20))
AS
Begin
    INSERT INTO @tab

    SELECT c3.name 
    FROM Club c3
    WHERE c3.name != @cname AND c3.name NOT IN 
                    ((SELECT c2.name
                    FROM Club c1
                    INNER JOIN Match m
                        ON c1.club_id = m.host_club_id
                    INNER JOIN Club c2
                        ON c2.club_id = m.guest_club_id
                    WHERE c1.name = @cname AND c2.name != @cname AND m.start_time < CURRENT_TIMESTAMP)
                UNION
                    (SELECT c2.name
                    FROM Club c1
                    INNER JOIN Match m
                        ON c1.club_id = m.guest_club_id
                    INNER JOIN Club c2
                        ON c2.club_id = m.host_club_id
                    WHERE c1.name = @cname AND c2.name != @cname AND m.start_time < CURRENT_TIMESTAMP))
    RETURN
END
GO



--29 Done

GO
CREATE FUNCTION [matchWithHighestAttendance]()
Returns @tab TABLE (Host VARCHAR(20), Guest VARCHAR(20))
AS
Begin
    INSERT INTO @tab
    
    SELECT TOP 1 c1.name AS Host, c2.name AS Guest
    FROM Ticket t
    INNER JOIN Match m
        ON m.match_id = t.match_id
    INNER JOIN Club c1
        ON m.host_club_id = c1.club_id
    INNER JOIN Club c2
        ON m.guest_club_id = c2.club_id
    WHERE t.status = 0
    GROUP BY t.match_id, c1.name, c2.name
    ORDER BY count(t.match_id) DESC

    RETURN
END

--30 Done

GO
CREATE FUNCTION [matchesRankedByAttendance]()
Returns @tab TABLE (host VARCHAR(20), guest VARCHAR(20))
AS
Begin
    INSERT INTO @tab
    
    SELECT c1.name AS Host, c2.name AS Guest
    FROM Ticket t
    INNER JOIN Match m
        ON m.match_id = t.match_id
    INNER JOIN Club c1
        ON m.host_club_id = c1.club_id
    INNER JOIN Club c2
        ON m.guest_club_id = c2.club_id
    WHERE t.status = 0 AND m.start_time < CURRENT_TIMESTAMP
    GROUP BY t.match_id, c1.name, c2.name
    ORDER BY count(t.match_id) DESC

    RETURN
END
GO

--31 DONE
GO
CREATE FUNCTION [requestsFromClub] 
(@Stad_name VARCHAR(20), @club_name VARCHAR(20))
RETURNS @T TABLE(host VARCHAR(20), guest VARCHAR(20))
AS
BEGIN
INSERT INTO @T
SELECT c1.name, c2.name
FROM Match m
INNER JOIN Club C1 ON m.host_club_id = c1.club_id
INNER JOIN Club C2 ON m.guest_club_id = c2.club_id
INNER JOIN Stadium s ON m.stadium_id = s.sid
INNER JOIN HostRequest h ON h.match_id = m.match_id
WHERE s.name = @Stad_name AND c1.name = @club_name

RETURN 
END
GO
