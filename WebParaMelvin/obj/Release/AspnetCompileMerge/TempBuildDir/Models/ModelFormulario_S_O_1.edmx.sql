
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/20/2023 21:02:39
-- Generated from EDMX file: D:\new Web para melvin\WebParaMelvin\Models\ModelFormulario_S_O_1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [cisam_form_s_o];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[cisam_ceisamco_cisam].[FK_Actividades_1_Usuarios_1]', 'F') IS NOT NULL
    ALTER TABLE [cisam_ceisamco_cisam].[Actividades] DROP CONSTRAINT [FK_Actividades_1_Usuarios_1];
GO
IF OBJECT_ID(N'[dbo].[FK_ArchivosExtras_ToFormulario_S_O]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArchivosExtras] DROP CONSTRAINT [FK_ArchivosExtras_ToFormulario_S_O];
GO
IF OBJECT_ID(N'[dbo].[FK_Audiometria_To_Formulario_S_O]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Audiometria] DROP CONSTRAINT [FK_Audiometria_To_Formulario_S_O];
GO
IF OBJECT_ID(N'[dbo].[FK_Consentimiento_Informado_To_Formulario_S_O]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Consentimiento_Informado] DROP CONSTRAINT [FK_Consentimiento_Informado_To_Formulario_S_O];
GO
IF OBJECT_ID(N'[dbo].[FK_CSO_To_Formulario_S_O]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CSO] DROP CONSTRAINT [FK_CSO_To_Formulario_S_O];
GO
IF OBJECT_ID(N'[dbo].[FK_EKG_To_Formulario_S_O]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EKG] DROP CONSTRAINT [FK_EKG_To_Formulario_S_O];
GO
IF OBJECT_ID(N'[dbo].[FK_Empresa_ToUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empresa] DROP CONSTRAINT [FK_Empresa_ToUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Espirometria_To_Formulario_S_O]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Espirometria] DROP CONSTRAINT [FK_Espirometria_To_Formulario_S_O];
GO
IF OBJECT_ID(N'[dbo].[FK_Examen_Visual_Formulario_S_O]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Examen_Visual] DROP CONSTRAINT [FK_Examen_Visual_Formulario_S_O];
GO
IF OBJECT_ID(N'[dbo].[FK_Formulario_S_O_ToTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Formulario_S_O] DROP CONSTRAINT [FK_Formulario_S_O_ToTable];
GO
IF OBJECT_ID(N'[dbo].[FK_Hemograma_To_Formulario_S_O]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Hemograma] DROP CONSTRAINT [FK_Hemograma_To_Formulario_S_O];
GO
IF OBJECT_ID(N'[dbo].[FK_Historia_clinica_To_Formulario_S_O_x]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Historia_Clinica] DROP CONSTRAINT [FK_Historia_clinica_To_Formulario_S_O_x];
GO
IF OBJECT_ID(N'[dbo].[FK_Laboratorio_ToFormularioSO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Laboratorio] DROP CONSTRAINT [FK_Laboratorio_ToFormularioSO];
GO
IF OBJECT_ID(N'[dbo].[FK_Mareo_To_Formulario_S_O]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mareo] DROP CONSTRAINT [FK_Mareo_To_Formulario_S_O];
GO
IF OBJECT_ID(N'[dbo].[FK_Pre_espirometria_To_Formulario_S_O]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pre_espirometria] DROP CONSTRAINT [FK_Pre_espirometria_To_Formulario_S_O];
GO
IF OBJECT_ID(N'[dbo].[FK_RayosX_To_Formulario_S_O]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RayosX] DROP CONSTRAINT [FK_RayosX_To_Formulario_S_O];
GO
IF OBJECT_ID(N'[ceisamco_form_s_oModelStoreContainer].[FK_Usuario_Empresa_ToEmpresa]', 'F') IS NOT NULL
    ALTER TABLE [ceisamco_form_s_oModelStoreContainer].[Usuario_Empresa] DROP CONSTRAINT [FK_Usuario_Empresa_ToEmpresa];
GO
IF OBJECT_ID(N'[ceisamco_form_s_oModelStoreContainer].[FK_Usuario_Empresa_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [ceisamco_form_s_oModelStoreContainer].[Usuario_Empresa] DROP CONSTRAINT [FK_Usuario_Empresa_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuario_Rol_ToRol]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario_Rol] DROP CONSTRAINT [FK_Usuario_Rol_ToRol];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuario_Rol_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario_Rol] DROP CONSTRAINT [FK_Usuario_Rol_Usuario];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[cisam_ceisamco_cisam].[Actividades]', 'U') IS NOT NULL
    DROP TABLE [cisam_ceisamco_cisam].[Actividades];
GO
IF OBJECT_ID(N'[dbo].[ArchivosExtras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArchivosExtras];
GO
IF OBJECT_ID(N'[dbo].[Audiometria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Audiometria];
GO
IF OBJECT_ID(N'[dbo].[Consentimiento_Informado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Consentimiento_Informado];
GO
IF OBJECT_ID(N'[dbo].[CSO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CSO];
GO
IF OBJECT_ID(N'[dbo].[EKG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EKG];
GO
IF OBJECT_ID(N'[dbo].[Empresa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empresa];
GO
IF OBJECT_ID(N'[dbo].[Espirometria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Espirometria];
GO
IF OBJECT_ID(N'[dbo].[Examen_Visual]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Examen_Visual];
GO
IF OBJECT_ID(N'[dbo].[Formulario_S_O]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Formulario_S_O];
GO
IF OBJECT_ID(N'[dbo].[Hemograma]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hemograma];
GO
IF OBJECT_ID(N'[dbo].[Historia_Clinica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Historia_Clinica];
GO
IF OBJECT_ID(N'[dbo].[Laboratorio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Laboratorio];
GO
IF OBJECT_ID(N'[dbo].[Mareo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mareo];
GO
IF OBJECT_ID(N'[dbo].[Pre_espirometria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pre_espirometria];
GO
IF OBJECT_ID(N'[dbo].[RayosX]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RayosX];
GO
IF OBJECT_ID(N'[dbo].[Rol]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rol];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO
IF OBJECT_ID(N'[dbo].[Usuario_Rol]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario_Rol];
GO
IF OBJECT_ID(N'[ceisamco_form_s_oModelStoreContainer].[Usuario_Empresa]', 'U') IS NOT NULL
    DROP TABLE [ceisamco_form_s_oModelStoreContainer].[Usuario_Empresa];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CSOes'
CREATE TABLE [dbo].[CSOes] (
    [Id_CSO] int IDENTITY(1,1) NOT NULL,
    [Antiguedad_en_el_puesto] nvarchar(20)  NULL,
    [Tiempo_en_la_empresa] nvarchar(20)  NULL,
    [Área_de_Trabajo] nvarchar(20)  NULL,
    [Anamnesis_ocupacional_ex_fisico] datetime  NULL,
    [Hemograma_completo] bit  NOT NULL,
    [Audiometria_tonal] bit  NOT NULL,
    [Gicemia] bit  NOT NULL,
    [Espirometria] bit  NOT NULL,
    [Urea_creatinina] bit  NOT NULL,
    [Panel_de_drogas_minimo_coc_thc_mtd_met] bit  NOT NULL,
    [Tuberculosis] bit  NOT NULL,
    [capacidad_fisica_test_manero] bit  NOT NULL,
    [Examen_de_orina] bit  NOT NULL,
    [Agudez_visual_agudeza_campo_profundidad_cromatismo] bit  NOT NULL,
    [Perfil_Lipidico] bit  NOT NULL,
    [Electrocardiograma_en_reposo] bit  NOT NULL,
    [TGO_TGP] bit  NOT NULL,
    [Radiografia_De_Torax_PA_Radiografia_lumbo_sacra] bit  NOT NULL,
    [HBSAG_Hepatitis_C] bit  NOT NULL,
    [Otros] nvarchar(50)  NULL,
    [Apto] bit  NOT NULL,
    [Apto_con_restriccion] bit  NOT NULL,
    [No_Apto] bit  NOT NULL,
    [Aplazado] bit  NOT NULL,
    [Recomendaciones_observaciones] nvarchar(max)  NULL,
    [Id_Formulario_S_O] int  NULL,
    [Firma] varbinary(max)  NULL,
    [Ultima_modificacion] datetime  NULL,
    [Usuario_que_modifico] int  NULL
);
GO

-- Creating table 'Empresas'
CREATE TABLE [dbo].[Empresas] (
    [Id_Empresa] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NULL,
    [RNC] nvarchar(50)  NULL,
    [Telefono_] nchar(30)  NULL,
    [Dirección] nvarchar(max)  NULL,
    [Persona_Contacto] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Sitio_Web] nvarchar(50)  NULL,
    [Id_Usuario] int  NULL,
    [Ultima_modificacion] datetime  NULL,
    [Usuario_que_modifico] int  NULL
);
GO

-- Creating table 'Formulario_S_O'
CREATE TABLE [dbo].[Formulario_S_O] (
    [Id_Formulario_S_O] int IDENTITY(1,1) NOT NULL,
    [Id_Usuario] int  NULL,
    [Id_Empresa] int  NULL,
    [Estado] nvarchar(50)  NULL,
    [Ultima_modificacion] datetime  NULL,
    [Usuario_que_modifico] int  NULL
);
GO

-- Creating table 'Rols'
CREATE TABLE [dbo].[Rols] (
    [Id_rol] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(50)  NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id_usuario] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(50)  NULL,
    [Password] nvarchar(20)  NULL,
    [id_rol] int  NULL,
    [Ultima_modificacion] datetime  NULL,
    [Usuario_que_modifico] int  NULL
);
GO

-- Creating table 'Usuario_Rol'
CREATE TABLE [dbo].[Usuario_Rol] (
    [Id_usuario_rol] int IDENTITY(1,1) NOT NULL,
    [Id_Rol] int  NULL,
    [Id_Usuario] int  NULL
);
GO

-- Creating table 'Usuario_Empresa'
CREATE TABLE [dbo].[Usuario_Empresa] (
    [Id_Usuario_Empresa] int IDENTITY(1,1) NOT NULL,
    [Id_Usuario] int  NULL,
    [Id_empresa] int  NULL
);
GO

-- Creating table 'ArchivosExtras'
CREATE TABLE [dbo].[ArchivosExtras] (
    [Id_ArchivoExtra] int IDENTITY(1,1) NOT NULL,
    [Id_Formulario_S_O] int  NULL,
    [Descripcion] nvarchar(100)  NULL,
    [link] nvarchar(150)  NULL
);
GO

-- Creating table 'Audiometrias'
CREATE TABLE [dbo].[Audiometrias] (
    [Id_AudioMetria] int IDENTITY(1,1) NOT NULL,
    [trabaja_trabajado_en_areas_ruidosas] bit  NOT NULL,
    [tipo_de_proteccion_auditiva] bit  NOT NULL,
    [Ha_tenido_infecciones_en_los_oidos] bit  NOT NULL,
    [Ha_tenido_zumbido_en_los_oidos] bit  NOT NULL,
    [Ha_estado_en_la_milicia_o_el_ejercito_no] bit  NULL,
    [trabaja_trabajado_en_areas_ruidosas_no] bit  NULL,
    [tipo_de_proteccion_auditiva_no] bit  NULL,
    [Ha_tenido_infecciones_en_los_oidos_no] bit  NULL,
    [Ha_tenido_zumbido_en_los_oidos_no] bit  NULL,
    [Ha_estado_en_la_milicia_o_el_ejercito] bit  NOT NULL,
    [Escucha_musica_alta_o_usa_audifonos] nvarchar(50)  NULL,
    [Horas_desde_la_ultima_exposicion] nvarchar(10)  NULL,
    [Exposicion] nvarchar(10)  NULL,
    [Entrenamiento_recibido] nvarchar(10)  NULL,
    [Autoevaluacion_de_su_audicion_] nvarchar(10)  NULL,
    [Otoscopia_Izquierda] nvarchar(50)  NULL,
    [Otoscopia_Derecha] nvarchar(50)  NULL,
    [Comentarios] nvarchar(max)  NULL,
    [Oiz_500] int  NULL,
    [Oiz_1K] int  NULL,
    [Oiz_2K] int  NULL,
    [Oiz_3K] int  NULL,
    [Oiz_4K] int  NULL,
    [Oiz_6K] int  NULL,
    [Oiz_8K] int  NULL,
    [Oiz_5002] int  NULL,
    [Oiz_1K2] int  NULL,
    [Oiz_2K2] int  NULL,
    [Oiz_3K2] int  NULL,
    [Oiz_4K2] int  NULL,
    [Oiz_6K2] int  NULL,
    [Oiz_8K2] int  NULL,
    [Ode_500] int  NULL,
    [Ode_1K] int  NULL,
    [Ode_2K] int  NULL,
    [Ode_3K] int  NULL,
    [Ode_4K] int  NULL,
    [Ode_6K] int  NULL,
    [Ode_8K] int  NULL,
    [Ode_5002] int  NULL,
    [Ode_1K2] int  NULL,
    [Ode_2K2] int  NULL,
    [Ode_3K2] int  NULL,
    [Ode_4K2] int  NULL,
    [Ode_6K2] int  NULL,
    [Ode_8K2] int  NULL,
    [Id_Formulario_S_O] int  NULL,
    [Firma] varbinary(max)  NULL,
    [Resultado] nvarchar(50)  NULL,
    [Modificado] bit  NULL,
    [Ultima_modificacion] datetime  NULL,
    [Usuario_que_modifico] int  NULL
);
GO

-- Creating table 'Consentimiento_Informado'
CREATE TABLE [dbo].[Consentimiento_Informado] (
    [Id_Consentimiento_Informado] int IDENTITY(1,1) NOT NULL,
    [Firma] varbinary(max)  NULL,
    [Huella] varbinary(max)  NULL,
    [Id_Formulario_S_O] int  NULL,
    [Modificado] bit  NULL,
    [Ultima_modificacion] datetime  NULL,
    [Usuario_que_modifico] int  NULL
);
GO

-- Creating table 'EKGs'
CREATE TABLE [dbo].[EKGs] (
    [Id_EKG] int IDENTITY(1,1) NOT NULL,
    [Archivo] varbinary(max)  NULL,
    [Id_Formulario_S_O] int  NULL,
    [Modificado] bit  NULL,
    [Ultima_modificacion] datetime  NULL,
    [Usuario_que_modifico] int  NULL
);
GO

-- Creating table 'Espirometrias'
CREATE TABLE [dbo].[Espirometrias] (
    [Id_Espirometria] int IDENTITY(1,1) NOT NULL,
    [Archivo] varbinary(max)  NULL,
    [Id_Formulario_S_O] int  NULL,
    [Resultado] nvarchar(50)  NULL,
    [Modificado] bit  NULL,
    [Ultima_modificacion] datetime  NULL,
    [Usuario_que_modifico] int  NULL
);
GO

-- Creating table 'Examen_Visual'
CREATE TABLE [dbo].[Examen_Visual] (
    [Id_Examen_Visual] int IDENTITY(1,1) NOT NULL,
    [Sin_corr_OD] int  NULL,
    [Sin_corr_OS] int  NULL,
    [Sin_corr_AO] int  NULL,
    [Con_corr_OD] int  NULL,
    [Con_corr_OS] int  NULL,
    [Con_corr_AO] int  NULL,
    [AVC_Ambos_ojos] nvarchar(50)  NULL,
    [Panorama_Normal_1] nchar(10)  NULL,
    [Panorama_Normal_2] nchar(10)  NULL,
    [Panorama_Normal_3] nchar(10)  NULL,
    [Panorama_Normal_4] nchar(10)  NULL,
    [Panorama_Normal_5] nchar(10)  NULL,
    [Panorama_Normal_6] nchar(10)  NULL,
    [Panorama_Normal_7] nchar(10)  NULL,
    [Panorama_Normal_8] nchar(10)  NULL,
    [Panorama_Normal_9] nchar(10)  NULL,
    [Panorama_Normal_10] nchar(10)  NULL,
    [Panorama_Normal_11] nchar(10)  NULL,
    [Deficiencias_Rojo_y_Verde_1] nchar(10)  NULL,
    [Deficiencias_Rojo_y_Verde_2] nchar(10)  NULL,
    [Deficiencias_Rojo_y_Verde_3] nchar(10)  NULL,
    [Deficiencias_Rojo_y_Verde_4] nchar(10)  NULL,
    [Deficiencias_Rojo_y_Verde_5] nchar(10)  NULL,
    [Deficiencias_Rojo_y_Verde_6] nchar(10)  NULL,
    [Deficiencias_Rojo_y_Verde_7] nchar(10)  NULL,
    [Deficiencias_Rojo_y_Verde_8] nchar(10)  NULL,
    [Deficiencias_Rojo_y_Verde_9] nchar(10)  NULL,
    [Deficiencias_Rojo_y_Verde_10] nchar(10)  NULL,
    [Deficiencias_Rojo_y_Verde_11] nchar(10)  NULL,
    [Ceguera_total_o_deilidad_cromatica_1] nchar(10)  NULL,
    [Ceguera_total_o_deilidad_cromatica_2] nchar(10)  NULL,
    [Ceguera_total_o_deilidad_cromatica_3] nchar(10)  NULL,
    [Ceguera_total_o_deilidad_cromatica_4] nchar(10)  NULL,
    [Ceguera_total_o_deilidad_cromatica_5] nchar(10)  NULL,
    [Ceguera_total_o_deilidad_cromatica_6] nchar(10)  NULL,
    [Ceguera_total_o_deilidad_cromatica_7] nchar(10)  NULL,
    [Ceguera_total_o_deilidad_cromatica_8] nchar(10)  NULL,
    [Ceguera_total_o_deilidad_cromatica_9] nchar(10)  NULL,
    [Ceguera_total_o_deilidad_cromatica_10] nchar(10)  NULL,
    [Ceguera_total_o_deilidad_cromatica_11] nchar(10)  NULL,
    [Respuesta_del_sujeto1] nchar(10)  NULL,
    [Respuesta_del_sujeto2] nchar(10)  NULL,
    [Respuesta_del_sujeto3] nchar(10)  NULL,
    [Respuesta_del_sujeto4] nchar(10)  NULL,
    [Respuesta_del_sujeto5] nchar(10)  NULL,
    [Respuesta_del_sujeto6] nchar(10)  NULL,
    [Respuesta_del_sujeto7] nchar(10)  NULL,
    [Respuesta_del_sujeto8] nchar(10)  NULL,
    [Respuesta_del_sujeto9] nchar(10)  NULL,
    [Respuesta_del_sujeto10] nchar(10)  NULL,
    [Respuesta_del_sujeto11] nchar(10)  NULL,
    [Ojo_derecho_TS] nchar(10)  NULL,
    [Ojo_derecho_NS] nchar(10)  NULL,
    [Ojo_derecho_TI] nchar(10)  NULL,
    [Ojo_derecho_NI] nchar(10)  NULL,
    [Ojo_izquierdo_TS] nchar(10)  NULL,
    [Ojo_izquierdo_NS] nchar(10)  NULL,
    [Ojo_izquierdo_TI] nchar(10)  NULL,
    [Ojo_izquierdo_NI] nchar(10)  NULL,
    [Persona_normal_12] int  NULL,
    [Deficiencia_rojo_y_verde_LEVE_12] int  NULL,
    [Protanopia_y_protanomalia_12] int  NULL,
    [Deuteranopia_y_deuteronomalia_12] int  NULL,
    [Respuesta_del_sujeto_12] int  NULL,
    [Persona_normal_13] int  NULL,
    [Deficiencia_rojo_y_verde_LEVE_13] int  NULL,
    [Protanopia_y_protanomalia_13] int  NULL,
    [Deuteranopia_y_deuteronomalia_13] int  NULL,
    [Respuesta_del_sujeto_13] int  NULL,
    [Respuesta_del_sujeto_14] nvarchar(max)  NULL,
    [Comentarios_] nvarchar(max)  NULL,
    [Agudeza_Visual_] nvarchar(50)  NULL,
    [Vision_cromatica] nvarchar(50)  NULL,
    [Campos_Visuales_OD] nvarchar(50)  NULL,
    [Campos_visuales_OS] nvarchar(50)  NULL,
    [Id_Formulario_S_O] int  NULL,
    [Firma] varbinary(max)  NULL,
    [Resultado] nvarchar(50)  NULL,
    [Modificado] bit  NULL,
    [Ultima_modificacion] datetime  NULL,
    [Usuario_que_modifico] int  NULL
);
GO

-- Creating table 'Hemogramas'
CREATE TABLE [dbo].[Hemogramas] (
    [Id_Hemograma] int IDENTITY(1,1) NOT NULL,
    [Archivo] varbinary(max)  NULL,
    [Id_Formulario_S_O] int  NULL,
    [Modificado] bit  NULL,
    [Ultima_modificacion] datetime  NULL,
    [Usuario_que_modifico] int  NULL
);
GO

-- Creating table 'Historia_Clinica'
CREATE TABLE [dbo].[Historia_Clinica] (
    [Id_Historia_Clinica] int IDENTITY(1,1) NOT NULL,
    [Estado_civil] nvarchar(50)  NULL,
    [Nivel_educacional] nvarchar(50)  NULL,
    [No_de_Hijos] int  NULL,
    [No_dependienteds] int  NULL,
    [Vivienda] nvarchar(50)  NULL,
    [Estatura] nvarchar(50)  NULL,
    [Calle] nvarchar(50)  NULL,
    [Numero_casa] int  NULL,
    [Ciudad] nvarchar(50)  NULL,
    [Sector] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [perosona_emergencia] nvarchar(50)  NULL,
    [H_empresa] nvarchar(50)  NULL,
    [H_Posicion] nvarchar(50)  NULL,
    [H_Dede_Hasta] nvarchar(50)  NULL,
    [Ex_Fisicos] bit  NOT NULL,
    [Ex_quimicos] bit  NOT NULL,
    [Ex_Hergonomico] bit  NOT NULL,
    [Ex_Psicosocial] bit  NOT NULL,
    [Ex_mecanico] bit  NOT NULL,
    [Ex_Electrico] bit  NOT NULL,
    [Ex_Biologico] bit  NOT NULL,
    [Ex_Locativo] bit  NOT NULL,
    [Epp] nchar(10)  NULL,
    [H_empresa1] nvarchar(50)  NULL,
    [H_Posicion1] nvarchar(50)  NULL,
    [H_Dede_Hasta1] nvarchar(50)  NULL,
    [Ex_Fisicos1] bit  NOT NULL,
    [Ex_quimicos1] bit  NOT NULL,
    [Ex_Hergonomico1] bit  NOT NULL,
    [Ex_Psicosocial1] bit  NOT NULL,
    [Ex_mecanico1] bit  NOT NULL,
    [Ex_Electrico1] bit  NOT NULL,
    [Ex_Biologico1] bit  NOT NULL,
    [Ex_Locativo1] bit  NOT NULL,
    [Epp1] nchar(10)  NULL,
    [H_empresa2] nvarchar(50)  NULL,
    [H_Posicion2] nvarchar(50)  NULL,
    [H_Dede_Hasta2] nvarchar(50)  NULL,
    [Ex_Fisicos2] bit  NOT NULL,
    [Ex_quimicos2] bit  NOT NULL,
    [Ex_Hergonomico2] bit  NOT NULL,
    [Ex_Psicosocial2] bit  NOT NULL,
    [Ex_mecanico2] bit  NOT NULL,
    [Ex_Biologico2] bit  NOT NULL,
    [Ex_Electrico2] bit  NOT NULL,
    [Ex_Locativo2] bit  NOT NULL,
    [Epp2] nchar(10)  NULL,
    [H_empresa3] nvarchar(50)  NULL,
    [H_Posicion3] nvarchar(50)  NULL,
    [H_Dede_Hasta3] nvarchar(50)  NULL,
    [Ex_Fisicos3] bit  NOT NULL,
    [Ex_quimicos3] bit  NOT NULL,
    [Ex_Hergonomico3] bit  NOT NULL,
    [Ex_Psicosocial3] bit  NOT NULL,
    [Ex_mecanico3] bit  NOT NULL,
    [Ex_Electrico3] bit  NOT NULL,
    [Ex_Biologico3] bit  NOT NULL,
    [Ex_Locativo3] bit  NOT NULL,
    [Epp3] nchar(10)  NULL,
    [H_empresa4] nvarchar(50)  NULL,
    [H_Posicion4] nvarchar(50)  NULL,
    [H_Dede_Hasta4] nvarchar(50)  NULL,
    [Ex_Fisicos4] bit  NOT NULL,
    [Ex_quimicos4] bit  NOT NULL,
    [Ex_Hergonomico4] bit  NOT NULL,
    [Ex_Psicosocial4] bit  NOT NULL,
    [Ex_mecanico4] bit  NOT NULL,
    [Ex_Electrico4] bit  NOT NULL,
    [Ex_Biologico4] bit  NOT NULL,
    [Ex_Locativo4] bit  NOT NULL,
    [Epp4] nchar(10)  NULL,
    [H_empresa5] nvarchar(50)  NULL,
    [H_Posicion5] nvarchar(50)  NULL,
    [H_Dede_Hasta5] nvarchar(50)  NULL,
    [Ex_Fisicos5] bit  NOT NULL,
    [Ex_quimicos5] bit  NOT NULL,
    [Ex_Hergonomico5] bit  NOT NULL,
    [Ex_Psicosocial5] bit  NOT NULL,
    [Ex_mecanico5] bit  NOT NULL,
    [Ex_Electrico5] bit  NOT NULL,
    [Ex_Biologico5] bit  NOT NULL,
    [Ex_Locativo5] bit  NOT NULL,
    [Epp5] nchar(10)  NULL,
    [Tipo_ocupacional] nvarchar(50)  NULL,
    [Dignostico_ocupacional] nvarchar(50)  NULL,
    [Empresa_ocupacional] nvarchar(50)  NULL,
    [Fecha_aporte_ARL] datetime  NULL,
    [Tipo_ocupacional1] nvarchar(50)  NULL,
    [Dignostico_ocupacional1] nvarchar(50)  NULL,
    [Empresa_ocupacional1] nvarchar(50)  NULL,
    [Fecha_aporte_ARL1] datetime  NULL,
    [Tipo_ocupacional2] nvarchar(50)  NULL,
    [Dignostico_ocupacional2] nvarchar(50)  NULL,
    [Empresa_ocupacional2] nvarchar(50)  NULL,
    [Fecha_aporte_ARL2] datetime  NULL,
    [Tipo_ocupacional3] nvarchar(50)  NULL,
    [Dignostico_ocupacional3] nvarchar(50)  NULL,
    [Empresa_ocupacional3] nvarchar(50)  NULL,
    [Fecha_aporte_ARL3] datetime  NULL,
    [Tipo_ocupacional4] nvarchar(50)  NULL,
    [Dignostico_ocupacional4] nvarchar(50)  NULL,
    [Empresa_ocupacional4] nvarchar(50)  NULL,
    [Fecha_aporte_ARL4] datetime  NULL,
    [Tipo_ocupacional5] nvarchar(50)  NULL,
    [Dignostico_ocupacional5] nvarchar(50)  NULL,
    [Empresa_ocupacional5] nvarchar(50)  NULL,
    [Fecha_aporte_ARL5] datetime  NULL,
    [ACV] bit  NOT NULL,
    [Asma] bit  NOT NULL,
    [Cancer] bit  NOT NULL,
    [Cervicalgia] bit  NOT NULL,
    [Chikungunya] bit  NOT NULL,
    [Dengue] bit  NOT NULL,
    [Diabetes] bit  NOT NULL,
    [ETS] bit  NOT NULL,
    [Enf_Auditiva] bit  NOT NULL,
    [Enf_Autoinmune] bit  NOT NULL,
    [Enf_Cardiaca] bit  NOT NULL,
    [Enf_Congenita] bit  NOT NULL,
    [Enf__Gastrica] bit  NOT NULL,
    [Enf_Mental] bit  NOT NULL,
    [Enf_Neurlogica] bit  NOT NULL,
    [Enf_Osteomuscular] bit  NOT NULL,
    [Enf_Renal] bit  NOT NULL,
    [Enf_Respiratoria] bit  NOT NULL,
    [Enf_Visual] bit  NOT NULL,
    [Epilepsia] bit  NOT NULL,
    [Gastritis] bit  NOT NULL,
    [Hepatitis] bit  NOT NULL,
    [Hernia_Abd_] bit  NOT NULL,
    [Hernia_discal] bit  NOT NULL,
    [Hipertencion] bit  NOT NULL,
    [Infarto_Cartdiaco] bit  NOT NULL,
    [Intoxicaciones] bit  NOT NULL,
    [Leptospirosis] bit  NOT NULL,
    [Lumbalgia] bit  NOT NULL,
    [Malaria] bit  NOT NULL,
    [Neumonia] bit  NOT NULL,
    [Tifoidea] bit  NOT NULL,
    [Tuberculosis] bit  NOT NULL,
    [Ulcera] bit  NOT NULL,
    [Vertigo] bit  NOT NULL,
    [Zika] bit  NOT NULL,
    [Detalle_Antecedentes] nvarchar(max)  NULL,
    [Antecendentes_Quirurgicos] nvarchar(max)  NULL,
    [Antecendentes_Traumaticos_] nvarchar(max)  NULL,
    [Antecendentes_Hospitalarios] nvarchar(max)  NULL,
    [Antecendentes_Transfucionales] nvarchar(max)  NULL,
    [Antecedentes_ginecologicos] nvarchar(50)  NULL,
    [FUM] nchar(10)  NULL,
    [G] nchar(10)  NULL,
    [P] nchar(10)  NULL,
    [C] nchar(10)  NULL,
    [A] nchar(10)  NULL,
    [Hepatitis_A] nchar(10)  NULL,
    [Fecha_Dosis_inm_HepaA] datetime  NULL,
    [Hepatitis_B] nchar(10)  NULL,
    [Fecha_Dosis_Inm_HepaB] datetime  NULL,
    [Influenza] nchar(10)  NULL,
    [Fecha_Dosis_Inm_Influenza] datetime  NULL,
    [Tetanos] nchar(10)  NULL,
    [Fecha_Dosis_Imn_Tetanos] datetime  NULL,
    [Alcohol] nvarchar(50)  NULL,
    [cantidad] int  NULL,
    [Medida] nchar(10)  NULL,
    [frecuencia] nvarchar(50)  NULL,
    [Tabaco] nvarchar(50)  NULL,
    [cantidad_ta] int  NULL,
    [Medida_ta] nchar(10)  NULL,
    [frecuencia_ta] nvarchar(50)  NULL,
    [Infuciones] nvarchar(50)  NULL,
    [cantidad_In] int  NULL,
    [Medida_In] nchar(10)  NULL,
    [frecuencia_In] nvarchar(50)  NULL,
    [Drogas] nvarchar(50)  NULL,
    [cantidad_dr] int  NULL,
    [Medida_dr] nchar(10)  NULL,
    [frecuencia_dr] nvarchar(50)  NULL,
    [medicamentos] nvarchar(max)  NULL,
    [Padre] nvarchar(50)  NULL,
    [Abuelo] nvarchar(50)  NULL,
    [AbueloM] nvarchar(50)  NULL,
    [Hermano] nvarchar(50)  NULL,
    [Madre] nvarchar(50)  NULL,
    [Abuela] nvarchar(50)  NULL,
    [AbuelaM] nvarchar(50)  NULL,
    [Tio] nvarchar(50)  NULL,
    [Sintomas_Generales] nvarchar(max)  NULL,
    [Sistema_Respirtatorio] nvarchar(max)  NULL,
    [Sistema_Cardiovascular] nvarchar(max)  NULL,
    [Sistema_GastroIntestinal] nvarchar(max)  NULL,
    [Sistema_GenitoUrinario] nvarchar(max)  NULL,
    [Sistema_Neurolgogico] nvarchar(max)  NULL,
    [Inspeccion] nvarchar(max)  NULL,
    [Tension_arterial] decimal(8,2)  NULL,
    [Tension_arterial2] decimal(8,2)  NULL,
    [Pulso] decimal(8,2)  NULL,
    [Respiracion] decimal(8,2)  NULL,
    [Peso_Lbs] decimal(8,2)  NULL,
    [Peso_Kgs] decimal(8,2)  NULL,
    [Talla_Pulg] decimal(8,2)  NULL,
    [Talla_Cms] decimal(8,2)  NULL,
    [Lateralidad_Dominante] nchar(10)  NULL,
    [IMC] decimal(8,2)  NULL,
    [IMC_Resul] nvarchar(50)  NULL,
    [Riesgo_Cardiovascular] nvarchar(50)  NULL,
    [Piel] bit  NOT NULL,
    [PielA] bit  NOT NULL,
    [Descripcion_Piel] nvarchar(max)  NULL,
    [Cabello] bit  NOT NULL,
    [CabelloA] bit  NOT NULL,
    [Descripcion_Cabellos] nvarchar(max)  NULL,
    [Ojos] bit  NOT NULL,
    [OjosA] bit  NOT NULL,
    [Descripcion_ojos] nvarchar(max)  NULL,
    [Oidos] bit  NOT NULL,
    [OidosA] bit  NOT NULL,
    [Descripcion_oidos] nvarchar(max)  NULL,
    [Nariz] bit  NOT NULL,
    [NarizA] bit  NOT NULL,
    [Descripcion_nariz] nvarchar(max)  NULL,
    [Boca] bit  NOT NULL,
    [BocaA] bit  NOT NULL,
    [Descripcion_boca] nvarchar(max)  NULL,
    [Faringe] bit  NOT NULL,
    [FaringeA] bit  NOT NULL,
    [Descripcion_faringe] nvarchar(max)  NULL,
    [Cuello] bit  NOT NULL,
    [CuelloA] bit  NOT NULL,
    [Descripcion_cuello] nvarchar(max)  NULL,
    [Pulmon] bit  NOT NULL,
    [PulmonA] bit  NOT NULL,
    [Descripcion_pulmon] nvarchar(max)  NULL,
    [Corzaon] bit  NOT NULL,
    [CorzaonA] bit  NOT NULL,
    [Descripcion_Corazon] nvarchar(max)  NULL,
    [Abdomen] bit  NOT NULL,
    [AbdomenA] bit  NOT NULL,
    [Descripcion_abdomen] nvarchar(max)  NULL,
    [Genitales] bit  NOT NULL,
    [GenitalesA] bit  NOT NULL,
    [descripcion_Genitales] nvarchar(max)  NULL,
    [Aparato_Locomotor] bit  NOT NULL,
    [Aparato_LocomotorA] bit  NOT NULL,
    [Descripcion_aparato_Locomotor] nvarchar(max)  NULL,
    [Marcha] bit  NOT NULL,
    [MarchaA] bit  NOT NULL,
    [Descripcion_Marcha] nvarchar(max)  NULL,
    [Columna] bit  NOT NULL,
    [ColumnaA] bit  NOT NULL,
    [Descripcion_Columna] nvarchar(max)  NULL,
    [Miembros_superiores] bit  NOT NULL,
    [Miembros_superioresA] bit  NOT NULL,
    [Descripcion_Miembros_superiores] nvarchar(max)  NULL,
    [Miembros_inferiores] bit  NOT NULL,
    [Miembros_inferioresA] bit  NOT NULL,
    [Descripcion_Miembros_Inferiores] nvarchar(max)  NULL,
    [Sistema_Nervioso] bit  NOT NULL,
    [Sistema_NerviosoA] bit  NOT NULL,
    [Descripcion_Sistema_Nervioso] nvarchar(max)  NULL,
    [Comentarios] nvarchar(max)  NULL,
    [Id_Formulario_S_O] int  NULL,
    [Firma] varbinary(max)  NULL,
    [Celular] nvarchar(30)  NULL,
    [Telefono] nvarchar(30)  NULL,
    [telefono_emergencia] nvarchar(30)  NULL,
    [Modificado] bit  NULL,
    [Ultima_modificacion] datetime  NULL,
    [Usuario_que_modifico] int  NULL
);
GO

-- Creating table 'Laboratorios'
CREATE TABLE [dbo].[Laboratorios] (
    [Id_Laboratorio] int IDENTITY(1,1) NOT NULL,
    [Color] nvarchar(50)  NULL,
    [Olor] nvarchar(50)  NULL,
    [Aspecto] nvarchar(50)  NULL,
    [PH] decimal(18,2)  NULL,
    [Densidad] int  NULL,
    [Nitritos] nvarchar(50)  NULL,
    [Glucosa] nvarchar(50)  NULL,
    [Albumina] nvarchar(50)  NULL,
    [Acetona] nvarchar(50)  NULL,
    [Bilirrubina] nvarchar(50)  NULL,
    [Urobilinógeno] nvarchar(50)  NULL,
    [Pigmentos_biliares] nvarchar(50)  NULL,
    [Hemoglobina] nvarchar(50)  NULL,
    [Sangre_oculta] nvarchar(50)  NULL,
    [Examen_Microscópico] nvarchar(50)  NULL,
    [Células_renales] nvarchar(50)  NULL,
    [Leucocitos] nvarchar(50)  NULL,
    [Hematíes] nvarchar(50)  NULL,
    [Células_epiteliales] nvarchar(50)  NULL,
    [Bacterias] nvarchar(50)  NULL,
    [Fibras_mucosas] nvarchar(50)  NULL,
    [Levaduras] nvarchar(50)  NULL,
    [Cristales] nvarchar(50)  NULL,
    [Cilindros] nvarchar(50)  NULL,
    [Parásitos] nvarchar(50)  NULL,
    [Id_Formulario_S_O] int  NULL,
    [firma] varbinary(max)  NULL,
    [Glicemia_alarma] nvarchar(50)  NULL,
    [Glicemia_Resultado] int  NULL,
    [Colesterol_total_alarma] nvarchar(50)  NULL,
    [Colesterol_total_resultado] int  NULL,
    [C_HDL_alarma] nvarchar(50)  NULL,
    [C_HDL_resultado] int  NULL,
    [SGPT_ALT_alarma] nvarchar(50)  NULL,
    [SGPT_ALT_resultado] int  NULL,
    [SGOT_ALT_alarma] nvarchar(50)  NULL,
    [SGOT_ALT_resultado] int  NULL,
    [C_LDL_alarma] nvarchar(50)  NULL,
    [C_LDL_resultado] int  NULL,
    [Creatinina_alarma] nvarchar(50)  NULL,
    [Creatinina_resultado] decimal(18,2)  NULL,
    [VDRL] nvarchar(50)  NULL,
    [Bacilo_de_Koch] nvarchar(50)  NULL,
    [HBsAg] nvarchar(50)  NULL,
    [HCV] nvarchar(50)  NULL,
    [Eritrosedimentacion] nvarchar(50)  NULL,
    [Cocaina] nvarchar(50)  NULL,
    [Anfetaminas] nvarchar(50)  NULL,
    [Opiaceos] nvarchar(50)  NULL,
    [Marihuana] nvarchar(50)  NULL,
    [Determinacion1] nvarchar(50)  NULL,
    [Alarma1] nvarchar(30)  NULL,
    [Resultado1] int  NULL,
    [Unidad1] nvarchar(30)  NULL,
    [Valor_de_Referencia_11] int  NULL,
    [Valor_de_Referencia_12] int  NULL,
    [Metodo1] nvarchar(50)  NULL,
    [Determinacion2] nvarchar(50)  NULL,
    [Alarma2] nvarchar(30)  NULL,
    [Resultado2] int  NULL,
    [Unidad2] nvarchar(30)  NULL,
    [Valor_de_Referencia_21] int  NULL,
    [Valor_de_Referencia_22] int  NULL,
    [Metodo2] nvarchar(50)  NULL,
    [Determinacion3] nvarchar(50)  NULL,
    [Alarma3] nvarchar(30)  NULL,
    [Resultado3] int  NULL,
    [Unidad3] nvarchar(30)  NULL,
    [Valor_de_Referencia_31] int  NULL,
    [Valor_de_Referencia_32] int  NULL,
    [Metodo3] nvarchar(50)  NULL,
    [Determinacion4] nvarchar(50)  NULL,
    [Alarma4] nvarchar(30)  NULL,
    [Resultado4] int  NULL,
    [Unidad4] nvarchar(30)  NULL,
    [Valor_de_Referencia_41] int  NULL,
    [Valor_de_Referencia_42] int  NULL,
    [Metodo4] nvarchar(50)  NULL,
    [Determinacion5] nvarchar(50)  NULL,
    [Alarma5] nvarchar(30)  NULL,
    [Resultado5] int  NULL,
    [Unidad5] nvarchar(30)  NULL,
    [Valor_de_Referencia_51] int  NULL,
    [Valor_de_Referencia_52] int  NULL,
    [Metodo5] nvarchar(50)  NULL,
    [Determinacion6] nvarchar(50)  NULL,
    [Alarma6] nvarchar(30)  NULL,
    [Resultado6] int  NULL,
    [Unidad6] nvarchar(30)  NULL,
    [Valor_de_Referencia_61] int  NULL,
    [Valor_de_Referencia_62] int  NULL,
    [Metodo6] nvarchar(50)  NULL,
    [Determinacion7] nvarchar(50)  NULL,
    [Alarma7] nvarchar(30)  NULL,
    [Resultado7] int  NULL,
    [Unidad7] nvarchar(30)  NULL,
    [Valor_de_Referencia_71] int  NULL,
    [Valor_de_Referencia_72] int  NULL,
    [Metodo7] nvarchar(50)  NULL,
    [Determinacion8] nvarchar(50)  NULL,
    [Alarma8] nvarchar(30)  NULL,
    [Resultado8] decimal(8,2)  NULL,
    [Unidad8] nvarchar(30)  NULL,
    [Valor_de_Referencia_81] decimal(8,2)  NULL,
    [Valor_de_Referencia_82] decimal(8,2)  NULL,
    [Metodo8] nvarchar(50)  NULL,
    [Determinacion9] nvarchar(50)  NULL,
    [Alarma9] nvarchar(30)  NULL,
    [Resultado9] int  NULL,
    [Unidad9] nvarchar(30)  NULL,
    [Valor_de_Referencia_91] int  NULL,
    [Valor_de_Referencia_92] int  NULL,
    [Metodo9] nvarchar(50)  NULL,
    [Determinacion10] nvarchar(50)  NULL,
    [Alarma10] nvarchar(30)  NULL,
    [Resultado10] int  NULL,
    [Unidad10] nvarchar(30)  NULL,
    [Valor_de_Referencia_101] int  NULL,
    [Valor_de_Referencia_102] int  NULL,
    [Metodo10] nvarchar(50)  NULL,
    [Determinacion11] nvarchar(50)  NULL,
    [Alarma11] nvarchar(30)  NULL,
    [Resultado11] int  NULL,
    [Unidad11] nvarchar(30)  NULL,
    [Valor_de_Referencia_111] int  NULL,
    [Valor_de_Referencia_112] int  NULL,
    [Metodo11] nvarchar(50)  NULL,
    [Determinacion12] nvarchar(50)  NULL,
    [Alarma12] nvarchar(30)  NULL,
    [Resultado12] int  NULL,
    [Unidad12] nvarchar(30)  NULL,
    [Valor_de_Referencia_121] int  NULL,
    [Valor_de_Referencia_122] int  NULL,
    [Metodo12] nvarchar(50)  NULL,
    [Serologia_condicion_1] nvarchar(50)  NULL,
    [Serologia_resultado_1] nvarchar(50)  NULL,
    [Serologia_metodo_1] nvarchar(50)  NULL,
    [Serologia_condicion_2] nvarchar(50)  NULL,
    [Serologia_resultado_2] nvarchar(50)  NULL,
    [Serologia_metodo_2] nvarchar(50)  NULL,
    [Serologia_condicion_3] nvarchar(50)  NULL,
    [Serologia_resultado_3] nvarchar(50)  NULL,
    [Serologia_metodo_3] nvarchar(50)  NULL,
    [Serologia_condicion_4] nvarchar(50)  NULL,
    [Serologia_resultado_4] nvarchar(50)  NULL,
    [Serologia_metodo_4] nvarchar(50)  NULL,
    [Firma1] varbinary(max)  NULL,
    [Trigliceridos_alarma] nvarchar(50)  NULL,
    [Trigliceridos_reultado] int  NULL,
    [Notas] nvarchar(max)  NULL,
    [Modificado] bit  NULL,
    [Ultima_modificacion] datetime  NULL,
    [Usuario_que_modifico] int  NULL
);
GO

-- Creating table 'Mareos'
CREATE TABLE [dbo].[Mareos] (
    [Id_Mareo] int IDENTITY(1,1) NOT NULL,
    [Peso] decimal(18,2)  NULL,
    [Pulso] decimal(18,2)  NULL,
    [Frecuencia_Cardiaca_Maxima] int  NULL,
    [Tension_Arterial1] decimal(18,2)  NULL,
    [Tension_Arterial2] decimal(18,2)  NULL,
    [C65__Frecuencia_Cartdiaca_Maxima] decimal(18,2)  NULL,
    [Primera_Carga] decimal(18,2)  NULL,
    [Segund_Carga] decimal(18,2)  NULL,
    [Tercera_Carga] decimal(18,2)  NULL,
    [Cuarta_Carga] decimal(18,2)  NULL,
    [Quinta_Carga] decimal(18,2)  NULL,
    [VO2Max] nchar(10)  NULL,
    [Factor_Correccion] nchar(10)  NULL,
    [Resultado] decimal(18,2)  NULL,
    [Resultado2] decimal(18,2)  NULL,
    [Comentario] nvarchar(max)  NULL,
    [Id_Formulario_S_O] int  NULL,
    [Firma] varbinary(max)  NULL,
    [Modificado] bit  NULL,
    [Ultima_modificacion] datetime  NULL,
    [Usuario_que_modifico] int  NULL
);
GO

-- Creating table 'Pre_espirometria'
CREATE TABLE [dbo].[Pre_espirometria] (
    [Id_Pre_espirometria] int IDENTITY(1,1) NOT NULL,
    [pulmon_torax_abdomen] bit  NOT NULL,
    [infarto_al_corazon] bit  NOT NULL,
    [retina_cirugia] bit  NOT NULL,
    [problema_corazon] bit  NOT NULL,
    [medicamento_tuberculosis] bit  NOT NULL,
    [Esta_embarazada] char(10)  NULL,
    [Presion_arterial] bit  NOT NULL,
    [infeccion_respirtatoria] bit  NOT NULL,
    [medicamento_respiracion] bit  NOT NULL,
    [cigarro_puro_pipa] bit  NOT NULL,
    [ejercicio_fuerte] bit  NOT NULL,
    [comida_completa] bit  NOT NULL,
    [Comentarios] nvarchar(max)  NULL,
    [Id_Formulario_S_O] int  NULL,
    [pulmon_torax_abdomenA] bit  NOT NULL,
    [infarto_al_corazonA] bit  NOT NULL,
    [retina_cirugiaA] bit  NOT NULL,
    [problema_corazonA] bit  NOT NULL,
    [medicamento_tuberculosisA] bit  NOT NULL,
    [Presion_arterialA] bit  NOT NULL,
    [infeccion_respirtatoriaA] bit  NOT NULL,
    [medicamento_respiracionA] bit  NOT NULL,
    [cigarro_puro_pipaA] bit  NOT NULL,
    [ejercicio_fuerteA] bit  NOT NULL,
    [comida_completaA] bit  NOT NULL,
    [Modificado] bit  NULL,
    [Ultima_modificacion] datetime  NULL,
    [Usuario_que_modifico] int  NULL
);
GO

-- Creating table 'RayosXes'
CREATE TABLE [dbo].[RayosXes] (
    [Id_rayos_X] int IDENTITY(1,1) NOT NULL,
    [tecnica] nvarchar(50)  NULL,
    [Hallasgos] nvarchar(max)  NULL,
    [Impresion_diagnostica] nvarchar(max)  NULL,
    [tecnica2] nvarchar(50)  NULL,
    [Hallasgos2] nvarchar(max)  NULL,
    [Impresion_diagnostica2] nvarchar(max)  NULL,
    [Id_Formulario_S_O] int  NULL,
    [Firma] varbinary(max)  NULL,
    [Firma2] varbinary(max)  NULL,
    [Modificado] bit  NULL,
    [Ultima_modificacion] datetime  NULL,
    [Usuario_que_modifico] int  NULL
);
GO

-- Creating table 'Actividades'
CREATE TABLE [dbo].[Actividades] (
    [Id_Actividad] int IDENTITY(1,1) NOT NULL,
    [Id_Usuario] int  NULL,
    [Fecha_modificacion] datetime  NULL,
    [descripcion] nvarchar(160)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id_CSO] in table 'CSOes'
ALTER TABLE [dbo].[CSOes]
ADD CONSTRAINT [PK_CSOes]
    PRIMARY KEY CLUSTERED ([Id_CSO] ASC);
GO

-- Creating primary key on [Id_Empresa] in table 'Empresas'
ALTER TABLE [dbo].[Empresas]
ADD CONSTRAINT [PK_Empresas]
    PRIMARY KEY CLUSTERED ([Id_Empresa] ASC);
GO

-- Creating primary key on [Id_Formulario_S_O] in table 'Formulario_S_O'
ALTER TABLE [dbo].[Formulario_S_O]
ADD CONSTRAINT [PK_Formulario_S_O]
    PRIMARY KEY CLUSTERED ([Id_Formulario_S_O] ASC);
GO

-- Creating primary key on [Id_rol] in table 'Rols'
ALTER TABLE [dbo].[Rols]
ADD CONSTRAINT [PK_Rols]
    PRIMARY KEY CLUSTERED ([Id_rol] ASC);
GO

-- Creating primary key on [Id_usuario] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id_usuario] ASC);
GO

-- Creating primary key on [Id_usuario_rol] in table 'Usuario_Rol'
ALTER TABLE [dbo].[Usuario_Rol]
ADD CONSTRAINT [PK_Usuario_Rol]
    PRIMARY KEY CLUSTERED ([Id_usuario_rol] ASC);
GO

-- Creating primary key on [Id_Usuario_Empresa] in table 'Usuario_Empresa'
ALTER TABLE [dbo].[Usuario_Empresa]
ADD CONSTRAINT [PK_Usuario_Empresa]
    PRIMARY KEY CLUSTERED ([Id_Usuario_Empresa] ASC);
GO

-- Creating primary key on [Id_ArchivoExtra] in table 'ArchivosExtras'
ALTER TABLE [dbo].[ArchivosExtras]
ADD CONSTRAINT [PK_ArchivosExtras]
    PRIMARY KEY CLUSTERED ([Id_ArchivoExtra] ASC);
GO

-- Creating primary key on [Id_AudioMetria] in table 'Audiometrias'
ALTER TABLE [dbo].[Audiometrias]
ADD CONSTRAINT [PK_Audiometrias]
    PRIMARY KEY CLUSTERED ([Id_AudioMetria] ASC);
GO

-- Creating primary key on [Id_Consentimiento_Informado] in table 'Consentimiento_Informado'
ALTER TABLE [dbo].[Consentimiento_Informado]
ADD CONSTRAINT [PK_Consentimiento_Informado]
    PRIMARY KEY CLUSTERED ([Id_Consentimiento_Informado] ASC);
GO

-- Creating primary key on [Id_EKG] in table 'EKGs'
ALTER TABLE [dbo].[EKGs]
ADD CONSTRAINT [PK_EKGs]
    PRIMARY KEY CLUSTERED ([Id_EKG] ASC);
GO

-- Creating primary key on [Id_Espirometria] in table 'Espirometrias'
ALTER TABLE [dbo].[Espirometrias]
ADD CONSTRAINT [PK_Espirometrias]
    PRIMARY KEY CLUSTERED ([Id_Espirometria] ASC);
GO

-- Creating primary key on [Id_Examen_Visual] in table 'Examen_Visual'
ALTER TABLE [dbo].[Examen_Visual]
ADD CONSTRAINT [PK_Examen_Visual]
    PRIMARY KEY CLUSTERED ([Id_Examen_Visual] ASC);
GO

-- Creating primary key on [Id_Hemograma] in table 'Hemogramas'
ALTER TABLE [dbo].[Hemogramas]
ADD CONSTRAINT [PK_Hemogramas]
    PRIMARY KEY CLUSTERED ([Id_Hemograma] ASC);
GO

-- Creating primary key on [Id_Historia_Clinica] in table 'Historia_Clinica'
ALTER TABLE [dbo].[Historia_Clinica]
ADD CONSTRAINT [PK_Historia_Clinica]
    PRIMARY KEY CLUSTERED ([Id_Historia_Clinica] ASC);
GO

-- Creating primary key on [Id_Laboratorio] in table 'Laboratorios'
ALTER TABLE [dbo].[Laboratorios]
ADD CONSTRAINT [PK_Laboratorios]
    PRIMARY KEY CLUSTERED ([Id_Laboratorio] ASC);
GO

-- Creating primary key on [Id_Mareo] in table 'Mareos'
ALTER TABLE [dbo].[Mareos]
ADD CONSTRAINT [PK_Mareos]
    PRIMARY KEY CLUSTERED ([Id_Mareo] ASC);
GO

-- Creating primary key on [Id_Pre_espirometria] in table 'Pre_espirometria'
ALTER TABLE [dbo].[Pre_espirometria]
ADD CONSTRAINT [PK_Pre_espirometria]
    PRIMARY KEY CLUSTERED ([Id_Pre_espirometria] ASC);
GO

-- Creating primary key on [Id_rayos_X] in table 'RayosXes'
ALTER TABLE [dbo].[RayosXes]
ADD CONSTRAINT [PK_RayosXes]
    PRIMARY KEY CLUSTERED ([Id_rayos_X] ASC);
GO

-- Creating primary key on [Id_Actividad] in table 'Actividades'
ALTER TABLE [dbo].[Actividades]
ADD CONSTRAINT [PK_Actividades]
    PRIMARY KEY CLUSTERED ([Id_Actividad] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Id_Formulario_S_O] in table 'CSOes'
ALTER TABLE [dbo].[CSOes]
ADD CONSTRAINT [FK_CSO_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CSO_To_Formulario_S_O'
CREATE INDEX [IX_FK_CSO_To_Formulario_S_O]
ON [dbo].[CSOes]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Usuario] in table 'Empresas'
ALTER TABLE [dbo].[Empresas]
ADD CONSTRAINT [FK_Empresa_ToUsuario]
    FOREIGN KEY ([Id_Usuario])
    REFERENCES [dbo].[Usuarios]
        ([Id_usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Empresa_ToUsuario'
CREATE INDEX [IX_FK_Empresa_ToUsuario]
ON [dbo].[Empresas]
    ([Id_Usuario]);
GO

-- Creating foreign key on [Id_Empresa] in table 'Formulario_S_O'
ALTER TABLE [dbo].[Formulario_S_O]
ADD CONSTRAINT [FK_Formulario_S_O_ToTable]
    FOREIGN KEY ([Id_Empresa])
    REFERENCES [dbo].[Empresas]
        ([Id_Empresa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Formulario_S_O_ToTable'
CREATE INDEX [IX_FK_Formulario_S_O_ToTable]
ON [dbo].[Formulario_S_O]
    ([Id_Empresa]);
GO

-- Creating foreign key on [Id_empresa] in table 'Usuario_Empresa'
ALTER TABLE [dbo].[Usuario_Empresa]
ADD CONSTRAINT [FK_Usuario_Empresa_ToEmpresa]
    FOREIGN KEY ([Id_empresa])
    REFERENCES [dbo].[Empresas]
        ([Id_Empresa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuario_Empresa_ToEmpresa'
CREATE INDEX [IX_FK_Usuario_Empresa_ToEmpresa]
ON [dbo].[Usuario_Empresa]
    ([Id_empresa]);
GO

-- Creating foreign key on [Id_Rol] in table 'Usuario_Rol'
ALTER TABLE [dbo].[Usuario_Rol]
ADD CONSTRAINT [FK_Usuario_Rol_ToRol]
    FOREIGN KEY ([Id_Rol])
    REFERENCES [dbo].[Rols]
        ([Id_rol])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuario_Rol_ToRol'
CREATE INDEX [IX_FK_Usuario_Rol_ToRol]
ON [dbo].[Usuario_Rol]
    ([Id_Rol]);
GO

-- Creating foreign key on [Id_Usuario] in table 'Usuario_Empresa'
ALTER TABLE [dbo].[Usuario_Empresa]
ADD CONSTRAINT [FK_Usuario_Empresa_Usuario]
    FOREIGN KEY ([Id_Usuario])
    REFERENCES [dbo].[Usuarios]
        ([Id_usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuario_Empresa_Usuario'
CREATE INDEX [IX_FK_Usuario_Empresa_Usuario]
ON [dbo].[Usuario_Empresa]
    ([Id_Usuario]);
GO

-- Creating foreign key on [Id_Usuario] in table 'Usuario_Rol'
ALTER TABLE [dbo].[Usuario_Rol]
ADD CONSTRAINT [FK_Usuario_Rol_Usuario]
    FOREIGN KEY ([Id_Usuario])
    REFERENCES [dbo].[Usuarios]
        ([Id_usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuario_Rol_Usuario'
CREATE INDEX [IX_FK_Usuario_Rol_Usuario]
ON [dbo].[Usuario_Rol]
    ([Id_Usuario]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'ArchivosExtras'
ALTER TABLE [dbo].[ArchivosExtras]
ADD CONSTRAINT [FK_ArchivosExtras_ToFormulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArchivosExtras_ToFormulario_S_O'
CREATE INDEX [IX_FK_ArchivosExtras_ToFormulario_S_O]
ON [dbo].[ArchivosExtras]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Audiometrias'
ALTER TABLE [dbo].[Audiometrias]
ADD CONSTRAINT [FK_Audiometria_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Audiometria_To_Formulario_S_O'
CREATE INDEX [IX_FK_Audiometria_To_Formulario_S_O]
ON [dbo].[Audiometrias]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Consentimiento_Informado'
ALTER TABLE [dbo].[Consentimiento_Informado]
ADD CONSTRAINT [FK_Consentimiento_Informado_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Consentimiento_Informado_To_Formulario_S_O'
CREATE INDEX [IX_FK_Consentimiento_Informado_To_Formulario_S_O]
ON [dbo].[Consentimiento_Informado]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'EKGs'
ALTER TABLE [dbo].[EKGs]
ADD CONSTRAINT [FK_EKG_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EKG_To_Formulario_S_O'
CREATE INDEX [IX_FK_EKG_To_Formulario_S_O]
ON [dbo].[EKGs]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Espirometrias'
ALTER TABLE [dbo].[Espirometrias]
ADD CONSTRAINT [FK_Espirometria_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Espirometria_To_Formulario_S_O'
CREATE INDEX [IX_FK_Espirometria_To_Formulario_S_O]
ON [dbo].[Espirometrias]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Examen_Visual'
ALTER TABLE [dbo].[Examen_Visual]
ADD CONSTRAINT [FK_Examen_Visual_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Examen_Visual_Formulario_S_O'
CREATE INDEX [IX_FK_Examen_Visual_Formulario_S_O]
ON [dbo].[Examen_Visual]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Hemogramas'
ALTER TABLE [dbo].[Hemogramas]
ADD CONSTRAINT [FK_Hemograma_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Hemograma_To_Formulario_S_O'
CREATE INDEX [IX_FK_Hemograma_To_Formulario_S_O]
ON [dbo].[Hemogramas]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Historia_Clinica'
ALTER TABLE [dbo].[Historia_Clinica]
ADD CONSTRAINT [FK_Historia_clinica_To_Formulario_S_O_x]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Historia_clinica_To_Formulario_S_O_x'
CREATE INDEX [IX_FK_Historia_clinica_To_Formulario_S_O_x]
ON [dbo].[Historia_Clinica]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Laboratorios'
ALTER TABLE [dbo].[Laboratorios]
ADD CONSTRAINT [FK_Laboratorio_ToFormularioSO]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Laboratorio_ToFormularioSO'
CREATE INDEX [IX_FK_Laboratorio_ToFormularioSO]
ON [dbo].[Laboratorios]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Mareos'
ALTER TABLE [dbo].[Mareos]
ADD CONSTRAINT [FK_Mareo_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Mareo_To_Formulario_S_O'
CREATE INDEX [IX_FK_Mareo_To_Formulario_S_O]
ON [dbo].[Mareos]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Pre_espirometria'
ALTER TABLE [dbo].[Pre_espirometria]
ADD CONSTRAINT [FK_Pre_espirometria_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pre_espirometria_To_Formulario_S_O'
CREATE INDEX [IX_FK_Pre_espirometria_To_Formulario_S_O]
ON [dbo].[Pre_espirometria]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'RayosXes'
ALTER TABLE [dbo].[RayosXes]
ADD CONSTRAINT [FK_RayosX_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RayosX_To_Formulario_S_O'
CREATE INDEX [IX_FK_RayosX_To_Formulario_S_O]
ON [dbo].[RayosXes]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Usuario] in table 'Actividades'
ALTER TABLE [dbo].[Actividades]
ADD CONSTRAINT [FK_Actividades_1_Usuarios_1]
    FOREIGN KEY ([Id_Usuario])
    REFERENCES [dbo].[Usuarios]
        ([Id_usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Actividades_1_Usuarios_1'
CREATE INDEX [IX_FK_Actividades_1_Usuarios_1]
ON [dbo].[Actividades]
    ([Id_Usuario]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------