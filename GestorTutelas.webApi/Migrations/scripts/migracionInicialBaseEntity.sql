﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE "Departamento" (
    id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Nombre" text NULL,
    CONSTRAINT "PK_Departamento" PRIMARY KEY (id)
);

CREATE TABLE "Parametro" (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "IdCategoria" integer NOT NULL,
    "IdParametro" integer NOT NULL,
    "DetalleCategoria" text NULL,
    "DetalleParametro" text NULL,
    CONSTRAINT "PK_Parametro" PRIMARY KEY (id)
);

CREATE TABLE "Rol" (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "Rol" text NULL,
    CONSTRAINT "PK_Rol" PRIMARY KEY (id)
);

CREATE TABLE usuario (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    usuario text NULL,
    contrasenha text NULL,
    CONSTRAINT "PK_usuario" PRIMARY KEY (id)
);

CREATE TABLE "Municipio" (
    id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Nombre" text NULL,
    "IdDepartamento" integer NOT NULL,
    CONSTRAINT "PK_Municipio" PRIMARY KEY (id),
    CONSTRAINT "FK_Municipio_Departamento_IdDepartamento" FOREIGN KEY ("IdDepartamento") REFERENCES "Departamento" (id) ON DELETE CASCADE
);

CREATE TABLE "ExpedienteDigital" (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "DerechoFundamental" integer NOT NULL,
    "Especialidad" integer NOT NULL,
    "EstadoExpediente" integer NOT NULL,
    "FechaRadicado" timestamp without time zone NOT NULL,
    "CodigoRadicado" text NULL,
    "IdMunicipioRadicado" integer NOT NULL,
    CONSTRAINT "PK_ExpedienteDigital" PRIMARY KEY (id),
    CONSTRAINT "FK_ExpedienteDigital_Municipio_IdMunicipioRadicado" FOREIGN KEY ("IdMunicipioRadicado") REFERENCES "Municipio" (id) ON DELETE CASCADE
);

CREATE TABLE "Persona" (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "Nombres" text NULL,
    "Apellidos" text NULL,
    "TipoDocumento" text NULL,
    "Documento" text NULL,
    "Direccion" text NULL,
    "Telefono" text NULL,
    "Celular" text NULL,
    "IdMunicipioResidencia" integer NOT NULL,
    "idUsuario" uuid NULL,
    CONSTRAINT "PK_Persona" PRIMARY KEY (id),
    CONSTRAINT "FK_Persona_Municipio_IdMunicipioResidencia" FOREIGN KEY ("IdMunicipioResidencia") REFERENCES "Municipio" (id) ON DELETE CASCADE,
    CONSTRAINT "FK_Persona_usuario_idUsuario" FOREIGN KEY ("idUsuario") REFERENCES usuario (id) ON DELETE RESTRICT
);

CREATE TABLE "ArchivoExpediente" (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    ruta text NULL,
    formato text NULL,
    tamanho text NULL,
    hash text NULL,
    "nombreCargado" text NULL,
    "nombreAsignado" text NULL,
    "TipoArchivo" integer NOT NULL,
    "idExpediente" uuid NOT NULL,
    CONSTRAINT "PK_ArchivoExpediente" PRIMARY KEY (id),
    CONSTRAINT "FK_ArchivoExpediente_ExpedienteDigital_idExpediente" FOREIGN KEY ("idExpediente") REFERENCES "ExpedienteDigital" (id) ON DELETE CASCADE
);

CREATE TABLE "PersonaRol" (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "idRol" uuid NOT NULL,
    "idPersona" uuid NOT NULL,
    CONSTRAINT "PK_PersonaRol" PRIMARY KEY (id),
    CONSTRAINT "FK_PersonaRol_Persona_idPersona" FOREIGN KEY ("idPersona") REFERENCES "Persona" (id) ON DELETE CASCADE,
    CONSTRAINT "FK_PersonaRol_Rol_idRol" FOREIGN KEY ("idRol") REFERENCES "Rol" (id) ON DELETE CASCADE
);

CREATE TABLE "PersonasExpediente" (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "idPersonaRol" uuid NOT NULL,
    "idExpediente" uuid NOT NULL,
    CONSTRAINT "PK_PersonasExpediente" PRIMARY KEY (id),
    CONSTRAINT "FK_PersonasExpediente_ExpedienteDigital_idExpediente" FOREIGN KEY ("idExpediente") REFERENCES "ExpedienteDigital" (id) ON DELETE CASCADE,
    CONSTRAINT "FK_PersonasExpediente_PersonaRol_idPersonaRol" FOREIGN KEY ("idPersonaRol") REFERENCES "PersonaRol" (id) ON DELETE CASCADE
);

CREATE TABLE "ProcesoExpediente" (
    id uuid NOT NULL DEFAULT (uuid_generate_v4()),
    "idPersonaRol" uuid NOT NULL,
    "idExpediente" uuid NOT NULL,
    "EstadoExpediente" integer NOT NULL,
    CONSTRAINT "PK_ProcesoExpediente" PRIMARY KEY (id),
    CONSTRAINT "FK_ProcesoExpediente_ExpedienteDigital_idExpediente" FOREIGN KEY ("idExpediente") REFERENCES "ExpedienteDigital" (id) ON DELETE CASCADE,
    CONSTRAINT "FK_ProcesoExpediente_PersonaRol_idPersonaRol" FOREIGN KEY ("idPersonaRol") REFERENCES "PersonaRol" (id) ON DELETE CASCADE
);

CREATE INDEX "IX_ArchivoExpediente_idExpediente" ON "ArchivoExpediente" ("idExpediente");

CREATE INDEX "IX_ExpedienteDigital_IdMunicipioRadicado" ON "ExpedienteDigital" ("IdMunicipioRadicado");

CREATE INDEX "IX_Municipio_IdDepartamento" ON "Municipio" ("IdDepartamento");

CREATE INDEX "IX_Persona_IdMunicipioResidencia" ON "Persona" ("IdMunicipioResidencia");

CREATE INDEX "IX_Persona_idUsuario" ON "Persona" ("idUsuario");

CREATE INDEX "IX_PersonaRol_idPersona" ON "PersonaRol" ("idPersona");

CREATE INDEX "IX_PersonaRol_idRol" ON "PersonaRol" ("idRol");

CREATE INDEX "IX_PersonasExpediente_idExpediente" ON "PersonasExpediente" ("idExpediente");

CREATE INDEX "IX_PersonasExpediente_idPersonaRol" ON "PersonasExpediente" ("idPersonaRol");

CREATE INDEX "IX_ProcesoExpediente_idExpediente" ON "ProcesoExpediente" ("idExpediente");

CREATE INDEX "IX_ProcesoExpediente_idPersonaRol" ON "ProcesoExpediente" ("idPersonaRol");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200410163705_InitialCreate', '3.1.3');

ALTER TABLE usuario ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE usuario ADD "UsuarioCrea" text NULL;

ALTER TABLE usuario ADD "UsuarioElimina" text NULL;

ALTER TABLE usuario ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE usuario ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE usuario ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE usuario ADD "usuarioModifica" text NULL;

ALTER TABLE "Rol" ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE "Rol" ADD "UsuarioCrea" text NULL;

ALTER TABLE "Rol" ADD "UsuarioElimina" text NULL;

ALTER TABLE "Rol" ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "Rol" ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "Rol" ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE "Rol" ADD "usuarioModifica" text NULL;

ALTER TABLE "ProcesoExpediente" ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE "ProcesoExpediente" ADD "UsuarioCrea" text NULL;

ALTER TABLE "ProcesoExpediente" ADD "UsuarioElimina" text NULL;

ALTER TABLE "ProcesoExpediente" ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "ProcesoExpediente" ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "ProcesoExpediente" ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE "ProcesoExpediente" ADD "usuarioModifica" text NULL;

ALTER TABLE "PersonasExpediente" ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE "PersonasExpediente" ADD "UsuarioCrea" text NULL;

ALTER TABLE "PersonasExpediente" ADD "UsuarioElimina" text NULL;

ALTER TABLE "PersonasExpediente" ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "PersonasExpediente" ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "PersonasExpediente" ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE "PersonasExpediente" ADD "usuarioModifica" text NULL;

ALTER TABLE "PersonaRol" ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE "PersonaRol" ADD "UsuarioCrea" text NULL;

ALTER TABLE "PersonaRol" ADD "UsuarioElimina" text NULL;

ALTER TABLE "PersonaRol" ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "PersonaRol" ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "PersonaRol" ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE "PersonaRol" ADD "usuarioModifica" text NULL;

ALTER TABLE "Persona" ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE "Persona" ADD "UsuarioCrea" text NULL;

ALTER TABLE "Persona" ADD "UsuarioElimina" text NULL;

ALTER TABLE "Persona" ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "Persona" ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "Persona" ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE "Persona" ADD "usuarioModifica" text NULL;

ALTER TABLE "Parametro" ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE "Parametro" ADD "UsuarioCrea" text NULL;

ALTER TABLE "Parametro" ADD "UsuarioElimina" text NULL;

ALTER TABLE "Parametro" ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "Parametro" ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "Parametro" ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE "Parametro" ADD "usuarioModifica" text NULL;

ALTER TABLE "Municipio" ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE "Municipio" ADD "UsuarioCrea" text NULL;

ALTER TABLE "Municipio" ADD "UsuarioElimina" text NULL;

ALTER TABLE "Municipio" ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "Municipio" ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "Municipio" ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE "Municipio" ADD "usuarioModifica" text NULL;

ALTER TABLE "ExpedienteDigital" ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE "ExpedienteDigital" ADD "UsuarioCrea" text NULL;

ALTER TABLE "ExpedienteDigital" ADD "UsuarioElimina" text NULL;

ALTER TABLE "ExpedienteDigital" ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "ExpedienteDigital" ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "ExpedienteDigital" ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE "ExpedienteDigital" ADD "usuarioModifica" text NULL;

ALTER TABLE "Departamento" ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE "Departamento" ADD "UsuarioCrea" text NULL;

ALTER TABLE "Departamento" ADD "UsuarioElimina" text NULL;

ALTER TABLE "Departamento" ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "Departamento" ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "Departamento" ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE "Departamento" ADD "usuarioModifica" text NULL;

ALTER TABLE "ArchivoExpediente" ADD "Estado" integer NOT NULL DEFAULT 0;

ALTER TABLE "ArchivoExpediente" ADD "UsuarioCrea" text NULL;

ALTER TABLE "ArchivoExpediente" ADD "UsuarioElimina" text NULL;

ALTER TABLE "ArchivoExpediente" ADD "fechaCreacion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "ArchivoExpediente" ADD "fechaEdicion" timestamp without time zone NOT NULL DEFAULT TIMESTAMP '0001-01-01 00:00:00';

ALTER TABLE "ArchivoExpediente" ADD "fechaEliminacion" timestamp without time zone NULL;

ALTER TABLE "ArchivoExpediente" ADD "usuarioModifica" text NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200410164012_InitialCreateBaseEntity', '3.1.3');

