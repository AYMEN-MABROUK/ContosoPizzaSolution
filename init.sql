--
-- PostgreSQL database dump
--

-- Dumped from database version 13.6
-- Dumped by pg_dump version 13.6

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: ContosoPizza; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA "ContosoPizza";


ALTER SCHEMA "ContosoPizza" OWNER TO postgres;

--
-- Name: SCHEMA "ContosoPizza"; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON SCHEMA "ContosoPizza" IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Customer; Type: TABLE; Schema: ContosoPizza; Owner: postgres
--

CREATE TABLE "ContosoPizza"."Customer" (
    "Id" bigint NOT NULL,
    "FirstName" text NOT NULL,
    "LastName" text NOT NULL,
    "Address" text,
    "Phone" text,
    "Email" text
);


ALTER TABLE "ContosoPizza"."Customer" OWNER TO postgres;

--
-- Name: Customer_Id_seq; Type: SEQUENCE; Schema: ContosoPizza; Owner: postgres
--

CREATE SEQUENCE "ContosoPizza"."Customer_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "ContosoPizza"."Customer_Id_seq" OWNER TO postgres;

--
-- Name: Customer_Id_seq; Type: SEQUENCE OWNED BY; Schema: ContosoPizza; Owner: postgres
--

ALTER SEQUENCE "ContosoPizza"."Customer_Id_seq" OWNED BY "ContosoPizza"."Customer"."Id";


--
-- Name: Order; Type: TABLE; Schema: ContosoPizza; Owner: postgres
--

CREATE TABLE "ContosoPizza"."Order" (
    "Id" bigint NOT NULL,
    "OrderPlaced" timestamp without time zone NOT NULL,
    "CustomerId" bigint NOT NULL,
    "OrderFulfilled" timestamp without time zone
);


ALTER TABLE "ContosoPizza"."Order" OWNER TO postgres;

--
-- Name: OrderDetails; Type: TABLE; Schema: ContosoPizza; Owner: postgres
--

CREATE TABLE "ContosoPizza"."OrderDetails" (
    "Id" bigint NOT NULL,
    "Quantity" integer NOT NULL,
    "OrderId" bigint NOT NULL,
    "ProductId" bigint NOT NULL
);


ALTER TABLE "ContosoPizza"."OrderDetails" OWNER TO postgres;

--
-- Name: OrderDetails_Id_seq; Type: SEQUENCE; Schema: ContosoPizza; Owner: postgres
--

CREATE SEQUENCE "ContosoPizza"."OrderDetails_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "ContosoPizza"."OrderDetails_Id_seq" OWNER TO postgres;

--
-- Name: OrderDetails_Id_seq; Type: SEQUENCE OWNED BY; Schema: ContosoPizza; Owner: postgres
--

ALTER SEQUENCE "ContosoPizza"."OrderDetails_Id_seq" OWNED BY "ContosoPizza"."OrderDetails"."Id";


--
-- Name: OrderDetails_OrderId_seq; Type: SEQUENCE; Schema: ContosoPizza; Owner: postgres
--

CREATE SEQUENCE "ContosoPizza"."OrderDetails_OrderId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "ContosoPizza"."OrderDetails_OrderId_seq" OWNER TO postgres;

--
-- Name: OrderDetails_OrderId_seq; Type: SEQUENCE OWNED BY; Schema: ContosoPizza; Owner: postgres
--

ALTER SEQUENCE "ContosoPizza"."OrderDetails_OrderId_seq" OWNED BY "ContosoPizza"."OrderDetails"."OrderId";


--
-- Name: OrderDetails_ProductId_seq; Type: SEQUENCE; Schema: ContosoPizza; Owner: postgres
--

CREATE SEQUENCE "ContosoPizza"."OrderDetails_ProductId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "ContosoPizza"."OrderDetails_ProductId_seq" OWNER TO postgres;

--
-- Name: OrderDetails_ProductId_seq; Type: SEQUENCE OWNED BY; Schema: ContosoPizza; Owner: postgres
--

ALTER SEQUENCE "ContosoPizza"."OrderDetails_ProductId_seq" OWNED BY "ContosoPizza"."OrderDetails"."ProductId";


--
-- Name: Order_CustomerId_seq; Type: SEQUENCE; Schema: ContosoPizza; Owner: postgres
--

CREATE SEQUENCE "ContosoPizza"."Order_CustomerId_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "ContosoPizza"."Order_CustomerId_seq" OWNER TO postgres;

--
-- Name: Order_CustomerId_seq; Type: SEQUENCE OWNED BY; Schema: ContosoPizza; Owner: postgres
--

ALTER SEQUENCE "ContosoPizza"."Order_CustomerId_seq" OWNED BY "ContosoPizza"."Order"."CustomerId";


--
-- Name: Order_Id_seq; Type: SEQUENCE; Schema: ContosoPizza; Owner: postgres
--

CREATE SEQUENCE "ContosoPizza"."Order_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "ContosoPizza"."Order_Id_seq" OWNER TO postgres;

--
-- Name: Order_Id_seq; Type: SEQUENCE OWNED BY; Schema: ContosoPizza; Owner: postgres
--

ALTER SEQUENCE "ContosoPizza"."Order_Id_seq" OWNED BY "ContosoPizza"."Order"."Id";


--
-- Name: Product; Type: TABLE; Schema: ContosoPizza; Owner: postgres
--

CREATE TABLE "ContosoPizza"."Product" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL,
    "Price" numeric(6,2) NOT NULL
);


ALTER TABLE "ContosoPizza"."Product" OWNER TO postgres;

--
-- Name: Product_Id_seq; Type: SEQUENCE; Schema: ContosoPizza; Owner: postgres
--

CREATE SEQUENCE "ContosoPizza"."Product_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "ContosoPizza"."Product_Id_seq" OWNER TO postgres;

--
-- Name: Product_Id_seq; Type: SEQUENCE OWNED BY; Schema: ContosoPizza; Owner: postgres
--

ALTER SEQUENCE "ContosoPizza"."Product_Id_seq" OWNED BY "ContosoPizza"."Product"."Id";


--
-- Name: AspNetRoleClaims; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetRoleClaims" (
    "Id" integer NOT NULL,
    "RoleId" text NOT NULL,
    "ClaimType" text,
    "ClaimValue" text
);


ALTER TABLE public."AspNetRoleClaims" OWNER TO postgres;

--
-- Name: AspNetRoleClaims_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."AspNetRoleClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetRoleClaims_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: AspNetRoles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetRoles" (
    "Id" text NOT NULL,
    "Name" character varying(256),
    "NormalizedName" character varying(256),
    "ConcurrencyStamp" text
);


ALTER TABLE public."AspNetRoles" OWNER TO postgres;

--
-- Name: AspNetUserClaims; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetUserClaims" (
    "Id" integer NOT NULL,
    "UserId" text NOT NULL,
    "ClaimType" text,
    "ClaimValue" text
);


ALTER TABLE public."AspNetUserClaims" OWNER TO postgres;

--
-- Name: AspNetUserClaims_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."AspNetUserClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetUserClaims_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: AspNetUserLogins; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetUserLogins" (
    "LoginProvider" text NOT NULL,
    "ProviderKey" text NOT NULL,
    "ProviderDisplayName" text,
    "UserId" text NOT NULL
);


ALTER TABLE public."AspNetUserLogins" OWNER TO postgres;

--
-- Name: AspNetUserRoles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetUserRoles" (
    "UserId" text NOT NULL,
    "RoleId" text NOT NULL
);


ALTER TABLE public."AspNetUserRoles" OWNER TO postgres;

--
-- Name: AspNetUserTokens; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetUserTokens" (
    "UserId" text NOT NULL,
    "LoginProvider" text NOT NULL,
    "Name" text NOT NULL,
    "Value" text
);


ALTER TABLE public."AspNetUserTokens" OWNER TO postgres;

--
-- Name: AspNetUsers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."AspNetUsers" (
    "Id" text NOT NULL,
    "UserName" character varying(256),
    "NormalizedUserName" character varying(256),
    "Email" character varying(256),
    "NormalizedEmail" character varying(256),
    "EmailConfirmed" boolean NOT NULL,
    "PasswordHash" text,
    "SecurityStamp" text,
    "ConcurrencyStamp" text,
    "PhoneNumber" text,
    "PhoneNumberConfirmed" boolean NOT NULL,
    "TwoFactorEnabled" boolean NOT NULL,
    "LockoutEnd" timestamp with time zone,
    "LockoutEnabled" boolean NOT NULL,
    "AccessFailedCount" integer NOT NULL
);


ALTER TABLE public."AspNetUsers" OWNER TO postgres;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- Name: Customer Id; Type: DEFAULT; Schema: ContosoPizza; Owner: postgres
--

ALTER TABLE ONLY "ContosoPizza"."Customer" ALTER COLUMN "Id" SET DEFAULT nextval('"ContosoPizza"."Customer_Id_seq"'::regclass);


--
-- Name: Order Id; Type: DEFAULT; Schema: ContosoPizza; Owner: postgres
--

ALTER TABLE ONLY "ContosoPizza"."Order" ALTER COLUMN "Id" SET DEFAULT nextval('"ContosoPizza"."Order_Id_seq"'::regclass);


--
-- Name: Order CustomerId; Type: DEFAULT; Schema: ContosoPizza; Owner: postgres
--

ALTER TABLE ONLY "ContosoPizza"."Order" ALTER COLUMN "CustomerId" SET DEFAULT nextval('"ContosoPizza"."Order_CustomerId_seq"'::regclass);


--
-- Name: OrderDetails Id; Type: DEFAULT; Schema: ContosoPizza; Owner: postgres
--

ALTER TABLE ONLY "ContosoPizza"."OrderDetails" ALTER COLUMN "Id" SET DEFAULT nextval('"ContosoPizza"."OrderDetails_Id_seq"'::regclass);


--
-- Name: OrderDetails OrderId; Type: DEFAULT; Schema: ContosoPizza; Owner: postgres
--

ALTER TABLE ONLY "ContosoPizza"."OrderDetails" ALTER COLUMN "OrderId" SET DEFAULT nextval('"ContosoPizza"."OrderDetails_OrderId_seq"'::regclass);


--
-- Name: OrderDetails ProductId; Type: DEFAULT; Schema: ContosoPizza; Owner: postgres
--

ALTER TABLE ONLY "ContosoPizza"."OrderDetails" ALTER COLUMN "ProductId" SET DEFAULT nextval('"ContosoPizza"."OrderDetails_ProductId_seq"'::regclass);


--
-- Name: Product Id; Type: DEFAULT; Schema: ContosoPizza; Owner: postgres
--

ALTER TABLE ONLY "ContosoPizza"."Product" ALTER COLUMN "Id" SET DEFAULT nextval('"ContosoPizza"."Product_Id_seq"'::regclass);


--
-- Data for Name: Customer; Type: TABLE DATA; Schema: ContosoPizza; Owner: postgres
--

COPY "ContosoPizza"."Customer" ("Id", "FirstName", "LastName", "Address", "Phone", "Email") FROM stdin;
1	FName_1	LName_1	address_1	58963741	FName_1.1@gmail.com
2	FName_2\n	LName_2	address_2	55123789	FName_2.2@gmail.com
3	FName_3	LName_3	address_3\n	50456123	FName_3.3@gmail.com
4	FName_4	LName_4	address_4	96258471	FName4.4@gmail.com
5	FName_5	LName_5	address_5	22951753	FName_5.5@gmail.com
6	string	string	string	string	string
7	string	string	string	string	string
\.


--
-- Data for Name: Order; Type: TABLE DATA; Schema: ContosoPizza; Owner: postgres
--

COPY "ContosoPizza"."Order" ("Id", "OrderPlaced", "CustomerId", "OrderFulfilled") FROM stdin;
2	2005-04-08 04:05:06	1	2005-04-08 10:30:46
3	2014-11-18 11:25:09	1	2014-11-20 12:15:20
4	2008-02-09 08:25:09	2	2008-02-11 14:25:33
5	2010-03-09 15:45:39	2	2010-03-14 08:55:00
6	1998-06-28 09:05:20	2	1998-06-28 12:35:45
8	2015-09-18 11:05:20	3	2015-09-18 13:15:25
9	2019-12-18 13:05:20	4	2019-12-18 14:45:50
10	2020-10-19 11:05:20	5	2020-10-19 15:35:36
11	2019-12-18 13:05:20	7	2019-12-19 13:05:20
\.


--
-- Data for Name: OrderDetails; Type: TABLE DATA; Schema: ContosoPizza; Owner: postgres
--

COPY "ContosoPizza"."OrderDetails" ("Id", "Quantity", "OrderId", "ProductId") FROM stdin;
5	20	2	5
6	4	2	3
7	30	2	1
8	4	3	2
9	18	3	4
10	8	3	5
11	45	4	2
12	3	4	1
13	90	4	3
14	6	5	3
15	4	5	5
16	16	6	3
17	35	6	4
20	9	8	4
21	10	8	2
22	17	9	3
23	50	9	1
24	99	10	5
4	99	10	3
\.


--
-- Data for Name: Product; Type: TABLE DATA; Schema: ContosoPizza; Owner: postgres
--

COPY "ContosoPizza"."Product" ("Id", "Name", "Price") FROM stdin;
1	product_1	150.55
2	product_2	500.35
3	product_3	250.80
4	product_4	1500.99
5	product_5	9999.99
\.


--
-- Data for Name: AspNetRoleClaims; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetRoleClaims" ("Id", "RoleId", "ClaimType", "ClaimValue") FROM stdin;
\.


--
-- Data for Name: AspNetRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetRoles" ("Id", "Name", "NormalizedName", "ConcurrencyStamp") FROM stdin;
\.


--
-- Data for Name: AspNetUserClaims; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserClaims" ("Id", "UserId", "ClaimType", "ClaimValue") FROM stdin;
\.


--
-- Data for Name: AspNetUserLogins; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserLogins" ("LoginProvider", "ProviderKey", "ProviderDisplayName", "UserId") FROM stdin;
\.


--
-- Data for Name: AspNetUserRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserRoles" ("UserId", "RoleId") FROM stdin;
\.


--
-- Data for Name: AspNetUserTokens; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUserTokens" ("UserId", "LoginProvider", "Name", "Value") FROM stdin;
\.


--
-- Data for Name: AspNetUsers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."AspNetUsers" ("Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount") FROM stdin;
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20220517140919_CreateIdentitySchema	6.0.5
\.


--
-- Name: Customer_Id_seq; Type: SEQUENCE SET; Schema: ContosoPizza; Owner: postgres
--

SELECT pg_catalog.setval('"ContosoPizza"."Customer_Id_seq"', 1, false);


--
-- Name: OrderDetails_Id_seq; Type: SEQUENCE SET; Schema: ContosoPizza; Owner: postgres
--

SELECT pg_catalog.setval('"ContosoPizza"."OrderDetails_Id_seq"', 1, false);


--
-- Name: OrderDetails_OrderId_seq; Type: SEQUENCE SET; Schema: ContosoPizza; Owner: postgres
--

SELECT pg_catalog.setval('"ContosoPizza"."OrderDetails_OrderId_seq"', 1, false);


--
-- Name: OrderDetails_ProductId_seq; Type: SEQUENCE SET; Schema: ContosoPizza; Owner: postgres
--

SELECT pg_catalog.setval('"ContosoPizza"."OrderDetails_ProductId_seq"', 1, false);


--
-- Name: Order_CustomerId_seq; Type: SEQUENCE SET; Schema: ContosoPizza; Owner: postgres
--

SELECT pg_catalog.setval('"ContosoPizza"."Order_CustomerId_seq"', 1, false);


--
-- Name: Order_Id_seq; Type: SEQUENCE SET; Schema: ContosoPizza; Owner: postgres
--

SELECT pg_catalog.setval('"ContosoPizza"."Order_Id_seq"', 1, false);


--
-- Name: Product_Id_seq; Type: SEQUENCE SET; Schema: ContosoPizza; Owner: postgres
--

SELECT pg_catalog.setval('"ContosoPizza"."Product_Id_seq"', 1, false);


--
-- Name: AspNetRoleClaims_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."AspNetRoleClaims_Id_seq"', 1, false);


--
-- Name: AspNetUserClaims_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."AspNetUserClaims_Id_seq"', 1, false);


--
-- Name: Customer Customer_pkey; Type: CONSTRAINT; Schema: ContosoPizza; Owner: postgres
--

ALTER TABLE ONLY "ContosoPizza"."Customer"
    ADD CONSTRAINT "Customer_pkey" PRIMARY KEY ("Id");


--
-- Name: OrderDetails OrderDetails_pkey; Type: CONSTRAINT; Schema: ContosoPizza; Owner: postgres
--

ALTER TABLE ONLY "ContosoPizza"."OrderDetails"
    ADD CONSTRAINT "OrderDetails_pkey" PRIMARY KEY ("Id");


--
-- Name: Order Order_pkey; Type: CONSTRAINT; Schema: ContosoPizza; Owner: postgres
--

ALTER TABLE ONLY "ContosoPizza"."Order"
    ADD CONSTRAINT "Order_pkey" PRIMARY KEY ("Id");


--
-- Name: Product Product_pkey; Type: CONSTRAINT; Schema: ContosoPizza; Owner: postgres
--

ALTER TABLE ONLY "ContosoPizza"."Product"
    ADD CONSTRAINT "Product_pkey" PRIMARY KEY ("Id");


--
-- Name: AspNetRoleClaims PK_AspNetRoleClaims; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetRoleClaims"
    ADD CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id");


--
-- Name: AspNetRoles PK_AspNetRoles; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetRoles"
    ADD CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id");


--
-- Name: AspNetUserClaims PK_AspNetUserClaims; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserClaims"
    ADD CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id");


--
-- Name: AspNetUserLogins PK_AspNetUserLogins; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserLogins"
    ADD CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey");


--
-- Name: AspNetUserRoles PK_AspNetUserRoles; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId");


--
-- Name: AspNetUserTokens PK_AspNetUserTokens; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserTokens"
    ADD CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name");


--
-- Name: AspNetUsers PK_AspNetUsers; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUsers"
    ADD CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: EmailIndex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "EmailIndex" ON public."AspNetUsers" USING btree ("NormalizedEmail");


--
-- Name: IX_AspNetRoleClaims_RoleId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON public."AspNetRoleClaims" USING btree ("RoleId");


--
-- Name: IX_AspNetUserClaims_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_AspNetUserClaims_UserId" ON public."AspNetUserClaims" USING btree ("UserId");


--
-- Name: IX_AspNetUserLogins_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_AspNetUserLogins_UserId" ON public."AspNetUserLogins" USING btree ("UserId");


--
-- Name: IX_AspNetUserRoles_RoleId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_AspNetUserRoles_RoleId" ON public."AspNetUserRoles" USING btree ("RoleId");


--
-- Name: RoleNameIndex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "RoleNameIndex" ON public."AspNetRoles" USING btree ("NormalizedName");


--
-- Name: UserNameIndex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "UserNameIndex" ON public."AspNetUsers" USING btree ("NormalizedUserName");


--
-- Name: Order Customer_ID; Type: FK CONSTRAINT; Schema: ContosoPizza; Owner: postgres
--

ALTER TABLE ONLY "ContosoPizza"."Order"
    ADD CONSTRAINT "Customer_ID" FOREIGN KEY ("CustomerId") REFERENCES "ContosoPizza"."Customer"("Id") NOT VALID;


--
-- Name: OrderDetails Order_ID; Type: FK CONSTRAINT; Schema: ContosoPizza; Owner: postgres
--

ALTER TABLE ONLY "ContosoPizza"."OrderDetails"
    ADD CONSTRAINT "Order_ID" FOREIGN KEY ("OrderId") REFERENCES "ContosoPizza"."Order"("Id") ON DELETE CASCADE;


--
-- Name: OrderDetails Product_ID; Type: FK CONSTRAINT; Schema: ContosoPizza; Owner: postgres
--

ALTER TABLE ONLY "ContosoPizza"."OrderDetails"
    ADD CONSTRAINT "Product_ID" FOREIGN KEY ("ProductId") REFERENCES "ContosoPizza"."Product"("Id") NOT VALID;


--
-- Name: AspNetRoleClaims FK_AspNetRoleClaims_AspNetRoles_RoleId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetRoleClaims"
    ADD CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id") ON DELETE CASCADE;


--
-- Name: AspNetUserClaims FK_AspNetUserClaims_AspNetUsers_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserClaims"
    ADD CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;


--
-- Name: AspNetUserLogins FK_AspNetUserLogins_AspNetUsers_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserLogins"
    ADD CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;


--
-- Name: AspNetUserRoles FK_AspNetUserRoles_AspNetRoles_RoleId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id") ON DELETE CASCADE;


--
-- Name: AspNetUserRoles FK_AspNetUserRoles_AspNetUsers_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;


--
-- Name: AspNetUserTokens FK_AspNetUserTokens_AspNetUsers_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."AspNetUserTokens"
    ADD CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

