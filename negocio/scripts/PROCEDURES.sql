USE CATALOGO_WEB_DB
GO
/****** Object:  StoredProcedure [dbo].[insertarNuevo]    Script Date: 11/9/2023 17:06:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[insertarNuevo]
@email varchar(50),
@pass varchar(50)
as
insert into USERS (email, pass, admin) output inserted.id values (@email, @pass, 0)
GO
/****** Object:  StoredProcedure [dbo].[storedAltaArticulo]    Script Date: 11/9/2023 17:06:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[storedAltaArticulo]
@codigo varchar(50),
@nombre varchar(50),
@desc varchar(50),
@idMarca int,
@idCategoria int,
@img varchar(500),
@precio money
as
insert into ARTICULOS values (@codigo, @nombre, @desc, @idMarca, @IdCategoria, @img, @precio)
GO
/****** Object:  StoredProcedure [dbo].[storedListar]    Script Date: 11/9/2023 17:06:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[storedListar] as
Select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion TipoMarca, C.Descripcion TipoCategoria, ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria 
From ARTICULOS A, CATEGORIAS C, MARCAS M where C.Id = A.IdCategoria AND A.IdCategoria = M.Id
GO
/****** Object:  StoredProcedure [dbo].[storedModificarArticulo]    Script Date: 11/9/2023 17:06:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[storedModificarArticulo]
@codigo varchar(50),
@nombre varchar(50),
@desc varchar(50),
@idMarca int,
@idCategoria int,
@img varchar(500),
@precio money,
@id int
as
update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @desc, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @img, Precio = @precio where Id = @id
GO