

ALTER TABLE "Persona" DROP CONSTRAINT "FK_Persona_Municipio_IdMunicipioResidencia";

ALTER TABLE "Persona" ALTER COLUMN "IdMunicipioResidencia" TYPE integer;
ALTER TABLE "Persona" ALTER COLUMN "IdMunicipioResidencia" DROP NOT NULL;
ALTER TABLE "Persona" ALTER COLUMN "IdMunicipioResidencia" DROP DEFAULT;

ALTER TABLE "Persona" ADD "CorreoElectronico" text NULL;

ALTER TABLE "ExpedienteDigital" ADD "TerminosyCondiciones" boolean NOT NULL DEFAULT FALSE;

ALTER TABLE "Persona" ADD CONSTRAINT "FK_Persona_Municipio_IdMunicipioResidencia" FOREIGN KEY ("IdMunicipioResidencia") REFERENCES "Municipio" (id) ON DELETE RESTRICT;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200412183604_ActualizacionEntidades', '3.1.3');

ALTER TABLE public."Persona" ALTER COLUMN "IdMunicipioResidencia" DROP NOT NULL;

