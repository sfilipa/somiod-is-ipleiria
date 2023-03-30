CREATE TABLE [dbo].[Applications]
(
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	[Creation_dt] SMALLDATETIME NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UC_Application_Name] UNIQUE NONCLUSTERED ([Name] ASC)
)

CREATE TABLE [dbo].[Modules]
(
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	[Creation_dt] SMALLDATETIME NOT NULL,
	[Parent] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY (Parent) REFERENCES Applications(Id),
    --CONSTRAINT [UC_Modules_Name] UNIQUE NONCLUSTERED ([Name] ASC), 
)

CREATE TABLE [dbo].[Data]
(
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[Content] NVARCHAR (150) NOT NULL,
	[Creation_dt] SMALLDATETIME NOT NULL,
	[Parent] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY (Parent) REFERENCES Modules(Id),
)

CREATE TABLE [dbo].[Subscriptions]
(
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	[Creation_dt] SMALLDATETIME NOT NULL,
	[Parent] INT NOT NULL,
	[Event] NVARCHAR (150) NOT NULL,
	[Endpoint] NVARCHAR (150) NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY (Parent) REFERENCES Modules(Id)
)

INSERT INTO Applications (Name, Creation_dt) VALUES ('lighting', GETDATE())
INSERT INTO Modules (Name, Creation_dt, Parent) VALUES ('lightbulb', GETDATE(), 1)
INSERT INTO Data (Content, Creation_dt, Parent) VALUES ('ON', GETDATE(), 1)
INSERT INTO Subscriptions (Name, Creation_dt, Parent, Event, Endpoint) VALUES ('sub1', GETDATE(), 1, 'creation', '127.0.0.1')

