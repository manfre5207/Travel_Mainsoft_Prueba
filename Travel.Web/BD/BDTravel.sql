USE [master]
GO
/****** Object:  Database [BDTravel]    Script Date: 7/05/2023 5:25:48 p. m. ******/
CREATE DATABASE [BDTravel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDTravel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDTravel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDTravel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDTravel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BDTravel] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDTravel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDTravel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDTravel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDTravel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDTravel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDTravel] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDTravel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDTravel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDTravel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDTravel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDTravel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDTravel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDTravel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDTravel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDTravel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDTravel] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDTravel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDTravel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDTravel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDTravel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDTravel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDTravel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDTravel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDTravel] SET RECOVERY FULL 
GO
ALTER DATABASE [BDTravel] SET  MULTI_USER 
GO
ALTER DATABASE [BDTravel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDTravel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDTravel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDTravel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDTravel] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDTravel] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BDTravel', N'ON'
GO
ALTER DATABASE [BDTravel] SET QUERY_STORE = OFF
GO
USE [BDTravel]
GO
/****** Object:  Table [dbo].[tbAutores]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbAutores](
	[Id_Autor] [int] IDENTITY(1,1) NOT NULL,
	[Nombres_Autor] [varchar](45) NULL,
	[Apellidos_Autor] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Autor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbAutores_Libros]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbAutores_Libros](
	[Id_Autor_Libro] [int] IDENTITY(1,1) NOT NULL,
	[Id_Autor] [int] NULL,
	[ISBN] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Autor_Libro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbEditoriales]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbEditoriales](
	[Id_Editorial] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Editorial] [varchar](45) NULL,
	[Sede] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Editorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbLibros]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbLibros](
	[Id_Libro] [int] IDENTITY(1,1) NOT NULL,
	[ISBN] [int] NOT NULL,
	[Id_Editorial] [int] NULL,
	[Titulo] [varchar](45) NULL,
	[Sinopsis] [varchar](500) NULL,
	[N_Paginas] [varchar](45) NULL,
 CONSTRAINT [PK_tbLibros] PRIMARY KEY CLUSTERED 
(
	[Id_Libro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbUsuarios]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUsuarios](
	[Id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Usuario] [varchar](45) NULL,
	[Password] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbAutores] ON 

INSERT [dbo].[tbAutores] ([Id_Autor], [Nombres_Autor], [Apellidos_Autor]) VALUES (29, N'Gabriel', N'Garcia Marquez')
INSERT [dbo].[tbAutores] ([Id_Autor], [Nombres_Autor], [Apellidos_Autor]) VALUES (30, N'Ernest', N'Hemingway')
INSERT [dbo].[tbAutores] ([Id_Autor], [Nombres_Autor], [Apellidos_Autor]) VALUES (31, N'Oscar', N'Wilde')
SET IDENTITY_INSERT [dbo].[tbAutores] OFF
GO
SET IDENTITY_INSERT [dbo].[tbAutores_Libros] ON 

INSERT [dbo].[tbAutores_Libros] ([Id_Autor_Libro], [Id_Autor], [ISBN]) VALUES (25, 29, 2020)
INSERT [dbo].[tbAutores_Libros] ([Id_Autor_Libro], [Id_Autor], [ISBN]) VALUES (26, 30, 4040)
INSERT [dbo].[tbAutores_Libros] ([Id_Autor_Libro], [Id_Autor], [ISBN]) VALUES (27, 31, 6060)
SET IDENTITY_INSERT [dbo].[tbAutores_Libros] OFF
GO
SET IDENTITY_INSERT [dbo].[tbEditoriales] ON 

INSERT [dbo].[tbEditoriales] ([Id_Editorial], [Nombre_Editorial], [Sede]) VALUES (16, N'Carvajal', N'Medellín')
INSERT [dbo].[tbEditoriales] ([Id_Editorial], [Nombre_Editorial], [Sede]) VALUES (17, N'Planeta', N'Bogotá')
SET IDENTITY_INSERT [dbo].[tbEditoriales] OFF
GO
SET IDENTITY_INSERT [dbo].[tbLibros] ON 

INSERT [dbo].[tbLibros] ([Id_Libro], [ISBN], [Id_Editorial], [Titulo], [Sinopsis], [N_Paginas]) VALUES (24, 2020, 16, N'Cien años de soledad', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop p', N'426')
INSERT [dbo].[tbLibros] ([Id_Libro], [ISBN], [Id_Editorial], [Titulo], [Sinopsis], [N_Paginas]) VALUES (25, 4040, 17, N'The Killers', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop p', N'652')
INSERT [dbo].[tbLibros] ([Id_Libro], [ISBN], [Id_Editorial], [Titulo], [Sinopsis], [N_Paginas]) VALUES (26, 6060, 16, N'La isla misteriosa', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop p', N'610')
SET IDENTITY_INSERT [dbo].[tbLibros] OFF
GO
SET IDENTITY_INSERT [dbo].[tbUsuarios] ON 

INSERT [dbo].[tbUsuarios] ([Id_Usuario], [Nombre_Usuario], [Password]) VALUES (1, N'admin', N'81dc9bdb52d04dc20036dbd8313ed055')
SET IDENTITY_INSERT [dbo].[tbUsuarios] OFF
GO
/****** Object:  StoredProcedure [dbo].[spEditar_Autor]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spEditar_Autor]
@Id_Autor INT,
@Nombres_Autor VARCHAR(45),
@Apellidos_Autor VARCHAR(45)   
AS
BEGIN	
	SET NOCOUNT ON;

UPDATE [dbo].[tbAutores]
SET 
Nombres_Autor = @Nombres_Autor,
Apellidos_Autor = @Apellidos_Autor
WHERE Id_Autor = @Id_Autor
END
GO
/****** Object:  StoredProcedure [dbo].[spEditar_Autor_Libro]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spEditar_Autor_Libro]
@Id_Autor_Libro INT,
@Id_Autor INT,        
@ISBN INT

AS
BEGIN	
	SET NOCOUNT ON;

UPDATE [dbo].[tbAutores_Libros]
SET 
Id_Autor = @Id_Autor,
ISBN = @ISBN
WHERE Id_Autor_Libro = @Id_Autor_Libro
END
GO
/****** Object:  StoredProcedure [dbo].[spEditar_Editorial]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spEditar_Editorial]
@Id_Editorial INT,
@Nombre_Editorial VARCHAR(45),
@Sede VARCHAR(45)   
AS
BEGIN	
	SET NOCOUNT ON;

UPDATE [dbo].[tbEditoriales]
SET 
Nombre_Editorial = @Nombre_Editorial,
Sede = @Sede
WHERE Id_Editorial = @Id_Editorial
END
GO
/****** Object:  StoredProcedure [dbo].[spEditar_Libro]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spEditar_Libro]
@Id_Libro INT,        
@ISBN INT,
@Id_Editorial INT,
@Titulo VARCHAR(45),
@Sinopsis VARCHAR(500),
@N_Paginas VARCHAR(45)
AS
BEGIN	
	SET NOCOUNT ON;
UPDATE [dbo].[tbLibros]
SET 
ISBN = @ISBN,
Id_Editorial = @Id_Editorial,
Titulo = @Titulo,
Sinopsis = @Sinopsis,
N_Paginas = @N_Paginas

WHERE Id_Libro = @Id_Libro

END
GO
/****** Object:  StoredProcedure [dbo].[spEliminar_Autor]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Luis Alfredo Agudelo>
-- Create date: <23/01/2020>
-- Description:	<Validar Login>
-- =============================================
CREATE PROCEDURE [dbo].[spEliminar_Autor] 
@Id_Autor INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


    -- Insert statements for procedure here
	DELETE
	FROM [dbo].[tbAutores]
	WHERE Id_Autor = @Id_Autor

END
GO
/****** Object:  StoredProcedure [dbo].[spEliminar_Editorial]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Luis Alfredo Agudelo>
-- Create date: <23/01/2020>
-- Description:	<Validar Login>
-- =============================================
CREATE PROCEDURE [dbo].[spEliminar_Editorial] 
@Id_Editorial INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


    -- Insert statements for procedure here
	DELETE
	FROM [dbo].[tbEditoriales]
	WHERE Id_Editorial = @Id_Editorial


END
GO
/****** Object:  StoredProcedure [dbo].[spInsertar_Autor]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertar_Autor]
        
                @Nombres_Autor VARCHAR(45),
				@Apellidos_Autor VARCHAR(45)              
AS
BEGIN	
	SET NOCOUNT ON;
INSERT INTO [dbo].[tbAutores]

               ([Nombres_Autor],
				[Apellidos_Autor])
     VALUES
               (@Nombres_Autor,
                @Apellidos_Autor)
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertar_Autor_Libro]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertar_Autor_Libro]
@Id_Autor INT,        
@ISBN INT

AS
BEGIN	
	SET NOCOUNT ON;

INSERT INTO [dbo].[tbAutores_Libros]

               (Id_Autor,
				ISBN)
     VALUES
               (@Id_Autor,
                @ISBN)
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertar_Editorial]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertar_Editorial]
        
                @Nombre_Editorial VARCHAR(45),
				@Sede VARCHAR(45)              
AS
BEGIN	
	SET NOCOUNT ON;
INSERT INTO [dbo].[tbEditoriales]

               ([Nombre_Editorial],
				[Sede])
     VALUES
               (@Nombre_Editorial,
                @Sede)
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertar_Libro]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertar_Libro]
        
@ISBN INT,
@Id_Editorial INT,
@Titulo VARCHAR(45),
@Sinopsis VARCHAR(500),
@N_Paginas VARCHAR(45)
AS
BEGIN	
	SET NOCOUNT ON;

INSERT INTO [dbo].[tbLibros]

               (ISBN,
				Id_Editorial,
				Titulo,
				Sinopsis,
				N_Paginas)
     VALUES
               (@ISBN,
                @Id_Editorial,
				@Titulo,
				@Sinopsis,
				@N_Paginas)

SELECT @@IDENTITY AS Id
END
GO
/****** Object:  StoredProcedure [dbo].[spList_Autores]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Luis Alfredo Agudelo>
-- Create date: <23/01/2020>
-- Description:	<Validar Login>
-- =============================================
CREATE PROCEDURE [dbo].[spList_Autores] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


    -- Insert statements for procedure here
	SELECT *
	FROM [dbo].[tbAutores] 
	ORDER BY Nombres_Autor ASC

	SELECT 
	Id_Autor,
	CONCAT(Nombres_Autor, ' ', Apellidos_Autor) AS Nombres_Autor,
	Apellidos_Autor
	FROM [dbo].[tbAutores] 
	ORDER BY Nombres_Autor ASC



END
GO
/****** Object:  StoredProcedure [dbo].[spList_AutoresXId]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Luis Alfredo Agudelo>
-- Create date: <23/01/2020>
-- Description:	<Validar Login>
-- =============================================
CREATE PROCEDURE [dbo].[spList_AutoresXId] 
@Id_Autor INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


    -- Insert statements for procedure here
	SELECT *
	FROM [dbo].[tbAutores]
	WHERE Id_Autor = @Id_Autor

END
GO
/****** Object:  StoredProcedure [dbo].[spList_Editoriales]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Luis Alfredo Agudelo>
-- Create date: <23/01/2020>
-- Description:	<Validar Login>
-- =============================================
CREATE PROCEDURE [dbo].[spList_Editoriales] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


    -- Insert statements for procedure here
	SELECT *
	FROM [dbo].[tbEditoriales]
	ORDER BY Nombre_Editorial ASC

	SELECT 
	Id_Editorial,
	CONCAT(Nombre_Editorial, ' ',+'(' + Sede + ')') AS Nombre_Editorial,
	Sede
	FROM [dbo].[tbEditoriales]
	ORDER BY Nombre_Editorial ASC

END
GO
/****** Object:  StoredProcedure [dbo].[spList_EditorialesXId]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Luis Alfredo Agudelo>
-- Create date: <23/01/2020>
-- Description:	<Validar Login>
-- =============================================
CREATE PROCEDURE [dbo].[spList_EditorialesXId] 
@Id_Editorial INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


    -- Insert statements for procedure here
	SELECT *
	FROM [dbo].[tbEditoriales]
	WHERE Id_Editorial = @Id_Editorial

END
GO
/****** Object:  StoredProcedure [dbo].[spList_Libros]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spList_Libros] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


    -- Insert statements for procedure here
	SELECT 
	L.Id_Libro,
	L.ISBN,
	L.Titulo,
	CONCAT(A.Nombres_Autor, ' ', A.Apellidos_Autor) AS Nombres_Autor,
	E.Nombre_Editorial
	FROM [dbo].[tbLibros] L
	INNER JOIN [dbo].[tbAutores_Libros] AL ON L.ISBN = AL.ISBN
	INNER JOIN [dbo].[tbAutores] A ON AL.Id_Autor = A.Id_Autor
	INNER JOIN [dbo].[tbEditoriales] E ON L.Id_Editorial = E.Id_Editorial
	ORDER BY L.Titulo  ASC

END
GO
/****** Object:  StoredProcedure [dbo].[spList_LibrosXId]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spList_LibrosXId] 
@Id_Libro INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


    -- Insert statements for procedure here
	SELECT 
	L.Id_Libro,
	L.ISBN,
	L.Titulo,
	L.Sinopsis,
	L.N_Paginas,
	L.Id_Editorial,
	A.Id_Autor,
	AL.Id_Autor_Libro
	FROM [dbo].[tbLibros] L
	INNER JOIN [dbo].[tbAutores_Libros] AL ON L.ISBN = AL.ISBN
	INNER JOIN [dbo].[tbAutores] A ON AL.Id_Autor = A.Id_Autor
	WHERE Id_Libro = @Id_Libro

END
GO
/****** Object:  StoredProcedure [dbo].[spUsuarios_Validar_Login]    Script Date: 7/05/2023 5:25:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Luis Alfredo Agudelo>
-- Create date: <23/01/2020>
-- Description:	<Validar Login>
-- =============================================
CREATE PROCEDURE [dbo].[spUsuarios_Validar_Login] 
	-- Add the parameters for the stored procedure here
	@Nombre_Usuario varchar(45),
	@Password nvarchar(300)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


    -- Insert statements for procedure here
	SELECT *
	FROM [dbo].[tbUsuarios] 
	WHERE Nombre_Usuario = @Nombre_Usuario AND Password = @Password
END
GO
USE [master]
GO
ALTER DATABASE [BDTravel] SET  READ_WRITE 
GO
