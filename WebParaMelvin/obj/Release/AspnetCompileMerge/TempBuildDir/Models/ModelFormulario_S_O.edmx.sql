
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/12/2018 15:08:20
-- Generated from EDMX file: D:\ProyectoMelvinWeb\WebParaMelvin\WebParaMelvin\Models\ModelFormulario_S_O.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ceisamco_form_s_o];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

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
IF OBJECT_ID(N'[dbo].[FK_Historia_Clinica_To_Formulario_S_O]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Historia_Clinica] DROP CONSTRAINT [FK_Historia_Clinica_To_Formulario_S_O];
GO
IF OBJECT_ID(N'[dbo].[FK_Info_general_To_Formulario_S_O]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Info_general] DROP CONSTRAINT [FK_Info_general_To_Formulario_S_O];
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
IF OBJECT_ID(N'[dbo].[FK_Usuario_Rol_ToRol]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario_Rol] DROP CONSTRAINT [FK_Usuario_Rol_ToRol];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuario_Rol_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario_Rol] DROP CONSTRAINT [FK_Usuario_Rol_Usuario];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

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
IF OBJECT_ID(N'[dbo].[Info_general]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Info_general];
GO
IF OBJECT_ID(N'[dbo].[Mareo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mareo];
GO
IF OBJECT_ID(N'[dbo].[Persona_empresa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persona_empresa];
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

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Audiometria'
CREATE TABLE [dbo].[Audiometria] (
    [Id_AudioMetria] int IDENTITY(1,1) NOT NULL,
    [trabaja_trabajado_en_areas_ruidosas] bit  NULL,
    [tipo_de_proteccion_auditiva] bit  NULL,
    [Ha_tenido_infecciones_en_los_oidos] bit  NULL,
    [Ha_tenido_zumbido_en_los_oidos] bit  NULL,
    [Ha_estado_en_la_milicia_o_el_ejercito] bit  NULL,
    [Escucha_musica_alta_o_usa_audifonos] nvarchar(50)  NULL,
    [Horas_desde_la_ultima_exposicion] nvarchar(10)  NULL,
    [Exposicion] nvarchar(10)  NULL,
    [Entrenamiento_recibido] nvarchar(10)  NULL,
    [Autoevaluacion_de_su_audicion_] nvarchar(10)  NULL,
    [Otoscopia_Izquierda] nvarchar(50)  NULL,
    [Otoscopia_Derecha] nvarchar(50)  NULL,
    [Comentarios] nvarchar(max)  NULL,
    [Oiz_500] decimal(18,2)  NULL,
    [Oiz_1K] decimal(18,2)  NULL,
    [Oiz_2K] decimal(18,2)  NULL,
    [Oiz_3K] decimal(18,2)  NULL,
    [Oiz_4K] decimal(18,2)  NULL,
    [Oiz_6K] decimal(18,2)  NULL,
    [Oiz_8K] decimal(18,2)  NULL,
    [Ode_500] decimal(18,2)  NULL,
    [Ode_1K] decimal(18,2)  NULL,
    [Ode_2K] decimal(18,2)  NULL,
    [Ode_3K] decimal(18,2)  NULL,
    [Ode_4K] decimal(18,2)  NULL,
    [Ode_6K] decimal(18,2)  NULL,
    [Ode_8K] decimal(18,2)  NULL,
    [Id_Formulario_S_O] int  NULL
);
GO

-- Creating table 'Consentimiento_Informado'
CREATE TABLE [dbo].[Consentimiento_Informado] (
    [Id_Consentimiento_Informado] int IDENTITY(1,1) NOT NULL,
    [Id_Formulario_S_O] int  NULL
);
GO

-- Creating table 'CSO'
CREATE TABLE [dbo].[CSO] (
    [Id_CSO] int IDENTITY(1,1) NOT NULL,
    [Antiguedad_en_el_puesto] nvarchar(20)  NULL,
    [Tiempo_en_la_empresa] nvarchar(20)  NULL,
    [Anamnesis_ocupacional_ex_fisico] datetime  NULL,
    [Hemograma_completo] bit  NULL,
    [Audiometria_tonal] bit  NULL,
    [Gicemia] bit  NULL,
    [Espirometria] bit  NULL,
    [Urea_creatinina] bit  NULL,
    [Panel_de_drogas_minimo_coc_thc_mtd_met] bit  NULL,
    [Tuberculosis] bit  NULL,
    [capacidad_fisica_test_manero] bit  NULL,
    [Examen_de_orina] bit  NULL,
    [Agudez_visual_agudeza_campo_profundidad_cromatismo] bit  NULL,
    [Perfil_Lipidico] bit  NULL,
    [Electrocardiograma_en_reposo] bit  NULL,
    [TGO_TGP] bit  NULL,
    [Radiografia_De_Torax_PA_Radiografia_lumbo_sacra] bit  NULL,
    [HBSAG_Hepatitis_C] bit  NULL,
    [Otros] nvarchar(50)  NULL,
    [Apto] bit  NULL,
    [Apto_con_restriccion] bit  NULL,
    [No_Apto] bit  NULL,
    [Aplazado] bit  NULL,
    [Recomendaciones_observaciones] nvarchar(max)  NULL,
    [Id_Formulario_S_O] int  NULL
);
GO

-- Creating table 'EKG'
CREATE TABLE [dbo].[EKG] (
    [Id_EKG] int IDENTITY(1,1) NOT NULL,
    [Id_Formulario_S_O] int  NULL
);
GO

-- Creating table 'Espirometria'
CREATE TABLE [dbo].[Espirometria] (
    [Id_Espirometria] int IDENTITY(1,1) NOT NULL,
    [Archivo] varbinary(max)  NULL,
    [Id_Formulario_S_O] int  NULL
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
    [Respuesta_del_sujeto_14] nvarchar(50)  NULL,
    [Comentarios_] nvarchar(max)  NULL,
    [Agudeza_Visual_] nvarchar(50)  NULL,
    [Vision_cromatica] nvarchar(50)  NULL,
    [Campos_Visuales_OD] nvarchar(50)  NULL,
    [Campos_visuales_OS] nvarchar(50)  NULL,
    [Id_Formulario_S_O] int  NULL
);
GO

-- Creating table 'Formulario_S_O'
CREATE TABLE [dbo].[Formulario_S_O] (
    [Id_Formulario_S_O] int IDENTITY(1,1) NOT NULL,
    [Id_Usuario] int  NULL,
    [Id_Empresa] int  NULL
);
GO

-- Creating table 'Hemograma'
CREATE TABLE [dbo].[Hemograma] (
    [Id_Hemograma] int IDENTITY(1,1) NOT NULL,
    [Archivo] varbinary(max)  NULL,
    [Id_Formulario_S_O] int  NULL
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
    [Celular] nvarchar(11)  NULL,
    [Telefono] nvarchar(11)  NULL,
    [Email] nvarchar(50)  NULL,
    [perosona_emergencia] nvarchar(50)  NULL,
    [telefono_emergencia] nvarchar(11)  NULL,
    [H_empresa] nvarchar(50)  NULL,
    [H_Posicion] nvarchar(50)  NULL,
    [H_Dede_Hasta] nvarchar(50)  NULL,
    [Ex_Fisicos] bit  NULL,
    [Ex_quimicos] bit  NULL,
    [Ex_Hergonomico] bit  NULL,
    [Ex_Psicosocial] bit  NULL,
    [Ex_mecanico] bit  NULL,
    [Ex_Electrico] bit  NULL,
    [Ex_Locativo] bit  NULL,
    [Epp] nchar(10)  NULL,
    [H_empresa1] nvarchar(50)  NULL,
    [H_Posicion1] nvarchar(50)  NULL,
    [H_Dede_Hasta1] nvarchar(50)  NULL,
    [Ex_Fisicos1] bit  NULL,
    [Ex_quimicos1] bit  NULL,
    [Ex_Hergonomico1] bit  NULL,
    [Ex_Psicosocial1] bit  NULL,
    [Ex_mecanico1] bit  NULL,
    [Ex_Electrico1] bit  NULL,
    [Ex_Locativo1] bit  NULL,
    [Epp1] nchar(10)  NULL,
    [H_empresa2] nvarchar(50)  NULL,
    [H_Posicion2] nvarchar(50)  NULL,
    [H_Dede_Hasta2] nvarchar(50)  NULL,
    [Ex_Fisicos2] bit  NULL,
    [Ex_quimicos2] bit  NULL,
    [Ex_Hergonomico2] bit  NULL,
    [Ex_Psicosocial2] bit  NULL,
    [Ex_mecanico2] bit  NULL,
    [Ex_Electrico2] bit  NULL,
    [Ex_Locativo2] bit  NULL,
    [Epp2] nchar(10)  NULL,
    [H_empresa3] nvarchar(50)  NULL,
    [H_Posicion3] nvarchar(50)  NULL,
    [H_Dede_Hasta3] nvarchar(50)  NULL,
    [Ex_Fisicos3] bit  NULL,
    [Ex_quimicos3] bit  NULL,
    [Ex_Hergonomico3] bit  NULL,
    [Ex_Psicosocial3] bit  NULL,
    [Ex_mecanico3] bit  NULL,
    [Ex_Electrico3] bit  NULL,
    [Ex_Locativo3] bit  NULL,
    [Epp3] nchar(10)  NULL,
    [H_empresa4] nvarchar(50)  NULL,
    [H_Posicion4] nvarchar(50)  NULL,
    [H_Dede_Hasta4] nvarchar(50)  NULL,
    [Ex_Fisicos4] bit  NULL,
    [Ex_quimicos4] bit  NULL,
    [Ex_Hergonomico4] bit  NULL,
    [Ex_Psicosocial4] bit  NULL,
    [Ex_mecanico4] bit  NULL,
    [Ex_Electrico4] bit  NULL,
    [Ex_Locativo4] bit  NULL,
    [Epp4] nchar(10)  NULL,
    [H_empresa5] nvarchar(50)  NULL,
    [H_Posicion5] nvarchar(50)  NULL,
    [H_Dede_Hasta5] nvarchar(50)  NULL,
    [Ex_Fisicos5] bit  NULL,
    [Ex_quimicos5] bit  NULL,
    [Ex_Hergonomico5] bit  NULL,
    [Ex_Psicosocial5] bit  NULL,
    [Ex_mecanico5] bit  NULL,
    [Ex_Electrico5] bit  NULL,
    [Ex_Locativo5] bit  NULL,
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
    [ACV] bit  NULL,
    [Asma] bit  NULL,
    [Cancer] bit  NULL,
    [Cervicalgia] bit  NULL,
    [Chikungunya] bit  NULL,
    [Dengue] bit  NULL,
    [Diabetes] bit  NULL,
    [ETS] bit  NULL,
    [Enf_Auditiva] bit  NULL,
    [Enf_Autoinmune] bit  NULL,
    [Enf_Cardiaca] bit  NULL,
    [Enf_Congenita] bit  NULL,
    [Enf__Gastrica] bit  NULL,
    [Enf_Mental] bit  NULL,
    [Enf_Neurlogica] bit  NULL,
    [Enf_Osteomuscular] bit  NULL,
    [Enf_Renal] bit  NULL,
    [Enf_Respiratoria] bit  NULL,
    [Enf_Visual] bit  NULL,
    [Epilepsia] bit  NULL,
    [Gastritis] bit  NULL,
    [Hepatitis] bit  NULL,
    [Hernia_Abd_] bit  NULL,
    [Hernia_discal] bit  NULL,
    [Hipertencion] bit  NULL,
    [Infarto_Cartdiaco] bit  NULL,
    [Intoxicaciones] bit  NULL,
    [Leptospirosis] bit  NULL,
    [Lumbalgia] bit  NULL,
    [Malaria] bit  NULL,
    [Neumonia] bit  NULL,
    [Tifoidea] bit  NULL,
    [Tuberculosis] bit  NULL,
    [Ulcera] bit  NULL,
    [Vertigo] bit  NULL,
    [Zika] bit  NULL,
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
    [Hepatitis_A] bit  NULL,
    [Fecha_Dosis_inm_HepaA] datetime  NULL,
    [Hepatitis_B] bit  NULL,
    [Fecha_Dosis_Inm_HepaB] datetime  NULL,
    [Influenza] bit  NULL,
    [Fecha_Dosis_Inm_Influenza] datetime  NULL,
    [Tetanos] bit  NULL,
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
    [Hermano] nvarchar(50)  NULL,
    [Madre] nvarchar(50)  NULL,
    [Abuela] nvarchar(50)  NULL,
    [Tio] nvarchar(50)  NULL,
    [Sintomas_Generales] nvarchar(max)  NULL,
    [Sistema_Respirtatorio] nvarchar(max)  NULL,
    [Sistema_Cardiovascular] nvarchar(max)  NULL,
    [Sistema_GastroIntestinal] nvarchar(max)  NULL,
    [Sistema_GenitoUrinario] nvarchar(max)  NULL,
    [Sistema_Neurolgogico] nvarchar(max)  NULL,
    [Inspeccion] nvarchar(max)  NULL,
    [Tension_arterial] nchar(10)  NULL,
    [Pulso] nchar(10)  NULL,
    [Respiracion] nchar(10)  NULL,
    [Peso] nchar(10)  NULL,
    [Talla] nchar(10)  NULL,
    [Lateralidad_Dominante] nchar(10)  NULL,
    [IMC] nvarchar(50)  NULL,
    [Riesgo_Cardiovascular] nvarchar(50)  NULL,
    [Piel] bit  NULL,
    [Descripcion_Piel] nvarchar(max)  NULL,
    [Cabello] bit  NULL,
    [Descripcion_Cabellos] nvarchar(max)  NULL,
    [Ojos] bit  NULL,
    [Descripcion_ojos] nvarchar(max)  NULL,
    [Oidos] bit  NULL,
    [Descripcion_oidos] nvarchar(max)  NULL,
    [Nariz] bit  NULL,
    [Descripcion_nariz] nvarchar(max)  NULL,
    [Boca] bit  NULL,
    [Descripcion_boca] nvarchar(max)  NULL,
    [Faringe] bit  NULL,
    [Descripcion_faringe] nvarchar(max)  NULL,
    [Cuello] bit  NULL,
    [Descripcion_cuello] nvarchar(max)  NULL,
    [Pulmon] bit  NULL,
    [Descripcion_pulmon] nvarchar(max)  NULL,
    [Corzaon] bit  NULL,
    [Descripcion_Corazon] nvarchar(max)  NULL,
    [Abdomen] bit  NULL,
    [Descripcion_abdomen] nvarchar(max)  NULL,
    [Genitales] bit  NULL,
    [descripcion_Genitales] nvarchar(max)  NULL,
    [Aparato_Locomotor] bit  NULL,
    [Descripcion_aparato_Locomotor] nvarchar(max)  NULL,
    [Marcha] bit  NULL,
    [Descripcion_Marcha] nvarchar(max)  NULL,
    [Columna] bit  NULL,
    [Descripcion_Columna] nvarchar(max)  NULL,
    [Miembros_superiores] bit  NULL,
    [Descripcion_Miembros_superiores] nvarchar(max)  NULL,
    [Miembros_inferiores] bit  NULL,
    [Descripcion_Miembros_Inferiores] nvarchar(max)  NULL,
    [Sistema_Nervioso] bit  NULL,
    [Descripcion_Sistema_Nervioso] varbinary(max)  NULL,
    [Comentarios] nvarchar(max)  NULL,
    [Id_Formulario_S_O] int  NULL
);
GO

-- Creating table 'Info_general'
CREATE TABLE [dbo].[Info_general] (
    [Id_Info_General] int  NOT NULL,
    [Empresa] nvarchar(50)  NULL,
    [Fecha] datetime  NULL,
    [Departamento] nvarchar(50)  NULL,
    [Posicion] nvarchar(50)  NULL,
    [Tipo_de_evaluacion] nvarchar(50)  NULL,
    [Nombre] nvarchar(50)  NULL,
    [Sexo] nvarchar(10)  NULL,
    [Cedula] nvarchar(11)  NULL,
    [Fecha_de_nacimiento] datetime  NULL,
    [Edad] nvarchar(50)  NULL,
    [Id_Empleado] int  NULL,
    [Id_Formulario_S_O] int  NULL
);
GO

-- Creating table 'Mareo'
CREATE TABLE [dbo].[Mareo] (
    [Id_Mareo] int IDENTITY(1,1) NOT NULL,
    [Peso] decimal(18,2)  NULL,
    [Pulso] decimal(18,2)  NULL,
    [Frecuencia_Cardiaca_Maxima] int  NULL,
    [Tension_Arterial1] decimal(18,2)  NULL,
    [Tension_Arterial2] decimal(18,2)  NULL,
    [C65__Frecuencia_Cartdiaca_Maxima] int  NULL,
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
    [Id_Formulario_S_O] int  NULL
);
GO

-- Creating table 'Persona_empresa'
CREATE TABLE [dbo].[Persona_empresa] (
    [Id_Persona_Empresa] int IDENTITY(1,1) NOT NULL,
    [Id_Usuario] nchar(10)  NULL,
    [Empresa] nvarchar(50)  NULL
);
GO

-- Creating table 'Pre_espirometria'
CREATE TABLE [dbo].[Pre_espirometria] (
    [Id_Pre_espirometria] int IDENTITY(1,1) NOT NULL,
    [pulmon_torax_abdomen] bit  NULL,
    [infarto_al_corazon] bit  NULL,
    [retina_cirugia] bit  NULL,
    [problema_corazon] bit  NULL,
    [medicamento_tuberculosis] bit  NULL,
    [Esta_embarazada] bit  NULL,
    [Presion_arterial] bit  NULL,
    [infeccion_respirtatoria] bit  NULL,
    [medicamento_respiracion] bit  NULL,
    [cigarro_puro_pipa] bit  NULL,
    [ejercicio_fuerte] bit  NULL,
    [comida_completa] bit  NULL,
    [Comentarios] nvarchar(max)  NULL,
    [Id_Formulario_S_O] int  NULL
);
GO

-- Creating table 'RayosX'
CREATE TABLE [dbo].[RayosX] (
    [Id_rayos_X] int IDENTITY(1,1) NOT NULL,
    [tecnica] nvarchar(50)  NULL,
    [Hallasgos] varbinary(max)  NULL,
    [Impresion_diagnostica] nvarchar(max)  NULL,
    [Id_Formulario_S_O] int  NULL
);
GO

-- Creating table 'Rol'
CREATE TABLE [dbo].[Rol] (
    [Id_rol] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(50)  NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [Id_usuario] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(50)  NULL,
    [Password] nvarchar(20)  NULL
);
GO

-- Creating table 'Usuario_Rol'
CREATE TABLE [dbo].[Usuario_Rol] (
    [Id_usuario_rol] int IDENTITY(1,1) NOT NULL,
    [Id_Rol] int  NULL,
    [Id_Usuario] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id_AudioMetria] in table 'Audiometria'
ALTER TABLE [dbo].[Audiometria]
ADD CONSTRAINT [PK_Audiometria]
    PRIMARY KEY CLUSTERED ([Id_AudioMetria] ASC);
GO

-- Creating primary key on [Id_Consentimiento_Informado] in table 'Consentimiento_Informado'
ALTER TABLE [dbo].[Consentimiento_Informado]
ADD CONSTRAINT [PK_Consentimiento_Informado]
    PRIMARY KEY CLUSTERED ([Id_Consentimiento_Informado] ASC);
GO

-- Creating primary key on [Id_CSO] in table 'CSO'
ALTER TABLE [dbo].[CSO]
ADD CONSTRAINT [PK_CSO]
    PRIMARY KEY CLUSTERED ([Id_CSO] ASC);
GO

-- Creating primary key on [Id_EKG] in table 'EKG'
ALTER TABLE [dbo].[EKG]
ADD CONSTRAINT [PK_EKG]
    PRIMARY KEY CLUSTERED ([Id_EKG] ASC);
GO

-- Creating primary key on [Id_Espirometria] in table 'Espirometria'
ALTER TABLE [dbo].[Espirometria]
ADD CONSTRAINT [PK_Espirometria]
    PRIMARY KEY CLUSTERED ([Id_Espirometria] ASC);
GO

-- Creating primary key on [Id_Examen_Visual] in table 'Examen_Visual'
ALTER TABLE [dbo].[Examen_Visual]
ADD CONSTRAINT [PK_Examen_Visual]
    PRIMARY KEY CLUSTERED ([Id_Examen_Visual] ASC);
GO

-- Creating primary key on [Id_Formulario_S_O] in table 'Formulario_S_O'
ALTER TABLE [dbo].[Formulario_S_O]
ADD CONSTRAINT [PK_Formulario_S_O]
    PRIMARY KEY CLUSTERED ([Id_Formulario_S_O] ASC);
GO

-- Creating primary key on [Id_Hemograma] in table 'Hemograma'
ALTER TABLE [dbo].[Hemograma]
ADD CONSTRAINT [PK_Hemograma]
    PRIMARY KEY CLUSTERED ([Id_Hemograma] ASC);
GO

-- Creating primary key on [Id_Historia_Clinica] in table 'Historia_Clinica'
ALTER TABLE [dbo].[Historia_Clinica]
ADD CONSTRAINT [PK_Historia_Clinica]
    PRIMARY KEY CLUSTERED ([Id_Historia_Clinica] ASC);
GO

-- Creating primary key on [Id_Info_General] in table 'Info_general'
ALTER TABLE [dbo].[Info_general]
ADD CONSTRAINT [PK_Info_general]
    PRIMARY KEY CLUSTERED ([Id_Info_General] ASC);
GO

-- Creating primary key on [Id_Mareo] in table 'Mareo'
ALTER TABLE [dbo].[Mareo]
ADD CONSTRAINT [PK_Mareo]
    PRIMARY KEY CLUSTERED ([Id_Mareo] ASC);
GO

-- Creating primary key on [Id_Persona_Empresa] in table 'Persona_empresa'
ALTER TABLE [dbo].[Persona_empresa]
ADD CONSTRAINT [PK_Persona_empresa]
    PRIMARY KEY CLUSTERED ([Id_Persona_Empresa] ASC);
GO

-- Creating primary key on [Id_Pre_espirometria] in table 'Pre_espirometria'
ALTER TABLE [dbo].[Pre_espirometria]
ADD CONSTRAINT [PK_Pre_espirometria]
    PRIMARY KEY CLUSTERED ([Id_Pre_espirometria] ASC);
GO

-- Creating primary key on [Id_rayos_X] in table 'RayosX'
ALTER TABLE [dbo].[RayosX]
ADD CONSTRAINT [PK_RayosX]
    PRIMARY KEY CLUSTERED ([Id_rayos_X] ASC);
GO

-- Creating primary key on [Id_rol] in table 'Rol'
ALTER TABLE [dbo].[Rol]
ADD CONSTRAINT [PK_Rol]
    PRIMARY KEY CLUSTERED ([Id_rol] ASC);
GO

-- Creating primary key on [Id_usuario] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([Id_usuario] ASC);
GO

-- Creating primary key on [Id_usuario_rol] in table 'Usuario_Rol'
ALTER TABLE [dbo].[Usuario_Rol]
ADD CONSTRAINT [PK_Usuario_Rol]
    PRIMARY KEY CLUSTERED ([Id_usuario_rol] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Id_Formulario_S_O] in table 'Audiometria'
ALTER TABLE [dbo].[Audiometria]
ADD CONSTRAINT [FK_Audiometria_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Audiometria_To_Formulario_S_O'
CREATE INDEX [IX_FK_Audiometria_To_Formulario_S_O]
ON [dbo].[Audiometria]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Consentimiento_Informado'
ALTER TABLE [dbo].[Consentimiento_Informado]
ADD CONSTRAINT [FK_Consentimiento_Informado_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Consentimiento_Informado_To_Formulario_S_O'
CREATE INDEX [IX_FK_Consentimiento_Informado_To_Formulario_S_O]
ON [dbo].[Consentimiento_Informado]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'CSO'
ALTER TABLE [dbo].[CSO]
ADD CONSTRAINT [FK_CSO_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CSO_To_Formulario_S_O'
CREATE INDEX [IX_FK_CSO_To_Formulario_S_O]
ON [dbo].[CSO]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'EKG'
ALTER TABLE [dbo].[EKG]
ADD CONSTRAINT [FK_EKG_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EKG_To_Formulario_S_O'
CREATE INDEX [IX_FK_EKG_To_Formulario_S_O]
ON [dbo].[EKG]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Espirometria'
ALTER TABLE [dbo].[Espirometria]
ADD CONSTRAINT [FK_Espirometria_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Espirometria_To_Formulario_S_O'
CREATE INDEX [IX_FK_Espirometria_To_Formulario_S_O]
ON [dbo].[Espirometria]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Examen_Visual'
ALTER TABLE [dbo].[Examen_Visual]
ADD CONSTRAINT [FK_Examen_Visual_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Examen_Visual_Formulario_S_O'
CREATE INDEX [IX_FK_Examen_Visual_Formulario_S_O]
ON [dbo].[Examen_Visual]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Usuario] in table 'Formulario_S_O'
ALTER TABLE [dbo].[Formulario_S_O]
ADD CONSTRAINT [FK_Formulario_S_O_ToTable]
    FOREIGN KEY ([Id_Usuario])
    REFERENCES [dbo].[Usuario]
        ([Id_usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Formulario_S_O_ToTable'
CREATE INDEX [IX_FK_Formulario_S_O_ToTable]
ON [dbo].[Formulario_S_O]
    ([Id_Usuario]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Hemograma'
ALTER TABLE [dbo].[Hemograma]
ADD CONSTRAINT [FK_Hemograma_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Hemograma_To_Formulario_S_O'
CREATE INDEX [IX_FK_Hemograma_To_Formulario_S_O]
ON [dbo].[Hemograma]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Historia_Clinica'
ALTER TABLE [dbo].[Historia_Clinica]
ADD CONSTRAINT [FK_Historia_Clinica_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Historia_Clinica_To_Formulario_S_O'
CREATE INDEX [IX_FK_Historia_Clinica_To_Formulario_S_O]
ON [dbo].[Historia_Clinica]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Info_general'
ALTER TABLE [dbo].[Info_general]
ADD CONSTRAINT [FK_Info_general_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Info_general_To_Formulario_S_O'
CREATE INDEX [IX_FK_Info_general_To_Formulario_S_O]
ON [dbo].[Info_general]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Mareo'
ALTER TABLE [dbo].[Mareo]
ADD CONSTRAINT [FK_Mareo_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Mareo_To_Formulario_S_O'
CREATE INDEX [IX_FK_Mareo_To_Formulario_S_O]
ON [dbo].[Mareo]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'Pre_espirometria'
ALTER TABLE [dbo].[Pre_espirometria]
ADD CONSTRAINT [FK_Pre_espirometria_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pre_espirometria_To_Formulario_S_O'
CREATE INDEX [IX_FK_Pre_espirometria_To_Formulario_S_O]
ON [dbo].[Pre_espirometria]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Formulario_S_O] in table 'RayosX'
ALTER TABLE [dbo].[RayosX]
ADD CONSTRAINT [FK_RayosX_To_Formulario_S_O]
    FOREIGN KEY ([Id_Formulario_S_O])
    REFERENCES [dbo].[Formulario_S_O]
        ([Id_Formulario_S_O])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RayosX_To_Formulario_S_O'
CREATE INDEX [IX_FK_RayosX_To_Formulario_S_O]
ON [dbo].[RayosX]
    ([Id_Formulario_S_O]);
GO

-- Creating foreign key on [Id_Rol] in table 'Usuario_Rol'
ALTER TABLE [dbo].[Usuario_Rol]
ADD CONSTRAINT [FK_Usuario_Rol_ToRol]
    FOREIGN KEY ([Id_Rol])
    REFERENCES [dbo].[Rol]
        ([Id_rol])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuario_Rol_ToRol'
CREATE INDEX [IX_FK_Usuario_Rol_ToRol]
ON [dbo].[Usuario_Rol]
    ([Id_Rol]);
GO

-- Creating foreign key on [Id_Usuario] in table 'Usuario_Rol'
ALTER TABLE [dbo].[Usuario_Rol]
ADD CONSTRAINT [FK_Usuario_Rol_Usuario]
    FOREIGN KEY ([Id_Usuario])
    REFERENCES [dbo].[Usuario]
        ([Id_usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuario_Rol_Usuario'
CREATE INDEX [IX_FK_Usuario_Rol_Usuario]
ON [dbo].[Usuario_Rol]
    ([Id_Usuario]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------