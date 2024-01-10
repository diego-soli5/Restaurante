USE Restaurante
go

INSERT INTO dbo.TREST_USUARIO(TC_Nombre,TC_NombreUsuario,TC_Contrasena,TC_CorreoElectronico,TB_Estado) VALUES('Alonso','alonso','10000.Rbdm5GPju5hph13Uu3FmwQ==.cf1S7TuGDbv5pgFXidaR6TjKTXDNwOF5wR+ATmf/EqY=','alonso@gmail.com',1);

INSERT INTO dbo.TREST_TIPOMENU(TC_DscTipoMenu,TB_Estado) VALUES('Tipo de Menu 1',1);
INSERT INTO dbo.TREST_TIPOMENU(TC_DscTipoMenu,TB_Estado) VALUES('Tipo de Menu 2',1);
INSERT INTO dbo.TREST_TIPOMENU(TC_DscTipoMenu,TB_Estado) VALUES('Tipo de Menu 3',1);

INSERT INTO dbo.TREST_MENU(TN_IdTipoMenu,TD_Precio,TC_DscMenu,TB_Estado) VALUES(1,100,'Menu 1',1);
INSERT INTO dbo.TREST_MENU(TN_IdTipoMenu,TD_Precio,TC_DscMenu,TB_Estado) VALUES(2,150,'Menu 2',0);

INSERT INTO dbo.TREST_CLIENTE(TC_Nombre,TC_Ap1,TC_Ap2,TC_NumTelefono,TC_CorreoElectronico,TB_Estado) VALUES('Luis','Castro','Castro','72345125','luiscastro@gmail.com',1);