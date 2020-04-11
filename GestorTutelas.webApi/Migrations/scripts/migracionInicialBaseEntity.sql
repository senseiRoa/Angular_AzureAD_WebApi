
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
VALUES ('20200411032529_InitialCreateBaseEntity', '3.1.3');

