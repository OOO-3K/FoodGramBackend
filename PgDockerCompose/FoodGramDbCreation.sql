--
-- PostgreSQL database dump
--

-- Dumped from database version 14.3 (Debian 14.3-1.pgdg110+1)
-- Dumped by pg_dump version 14.3 (Debian 14.3-1.pgdg110+1)

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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Favourites; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Favourites" (
    "UserId" uuid NOT NULL,
    "RecipeId" uuid NOT NULL
)
WITH (autovacuum_enabled='true');


ALTER TABLE public."Favourites" OWNER TO postgres;

--
-- Name: Ingredients; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Ingredients" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Unit" text NOT NULL
)
WITH (autovacuum_enabled='true');


ALTER TABLE public."Ingredients" OWNER TO postgres;

--
-- Name: RecipeComments; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RecipeComments" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "RecipeId" uuid NOT NULL,
    "CommentText" text NOT NULL
)
WITH (autovacuum_enabled='true');


ALTER TABLE public."RecipeComments" OWNER TO postgres;

--
-- Name: RecipeIngredients; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RecipeIngredients" (
    "IngredientId" uuid NOT NULL,
    "RecipeId" uuid NOT NULL,
    "Amount" real NOT NULL
)
WITH (autovacuum_enabled='true');


ALTER TABLE public."RecipeIngredients" OWNER TO postgres;

--
-- Name: RecipeStepComments; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RecipeStepComments" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "RecipeId" uuid NOT NULL,
    "StepId" uuid NOT NULL,
    "CommentText" text NOT NULL
)
WITH (autovacuum_enabled='true');


ALTER TABLE public."RecipeStepComments" OWNER TO postgres;

--
-- Name: RecipeSteps; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RecipeSteps" (
    "Id" uuid NOT NULL,
    "RecipeId" uuid NOT NULL,
    "StepNumber" integer NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    "ImagePath" text,
    "CookingTime" real NOT NULL
)
WITH (autovacuum_enabled='true');


ALTER TABLE public."RecipeSteps" OWNER TO postgres;

--
-- Name: Recipes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Recipes" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    "ImagePath" text,
    "CookingTime" real NOT NULL,
    "Rating" integer
)
WITH (autovacuum_enabled='true');


ALTER TABLE public."Recipes" OWNER TO postgres;

--
-- Name: Scores; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Scores" (
    "UserId" uuid NOT NULL,
    "RecipeId" uuid NOT NULL,
    "ScoreVal" integer NOT NULL
)
WITH (autovacuum_enabled='true');


ALTER TABLE public."Scores" OWNER TO postgres;

--
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "PasswordHash" text NOT NULL
)
WITH (autovacuum_enabled='true');


ALTER TABLE public."Users" OWNER TO postgres;

--
-- Data for Name: Favourites; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Favourites" ("UserId", "RecipeId") FROM stdin;
\.


--
-- Data for Name: Ingredients; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Ingredients" ("Id", "Name", "Unit") FROM stdin;
\.


--
-- Data for Name: RecipeComments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RecipeComments" ("Id", "UserId", "RecipeId", "CommentText") FROM stdin;
\.


--
-- Data for Name: RecipeIngredients; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RecipeIngredients" ("IngredientId", "RecipeId", "Amount") FROM stdin;
\.


--
-- Data for Name: RecipeStepComments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RecipeStepComments" ("Id", "UserId", "RecipeId", "StepId", "CommentText") FROM stdin;
\.


--
-- Data for Name: RecipeSteps; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RecipeSteps" ("Id", "RecipeId", "StepNumber", "Name", "Description", "ImagePath", "CookingTime") FROM stdin;
\.


--
-- Data for Name: Recipes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Recipes" ("Id", "Name", "Description", "ImagePath", "CookingTime", "Rating") FROM stdin;
\.


--
-- Data for Name: Scores; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Scores" ("UserId", "RecipeId", "ScoreVal") FROM stdin;
\.


--
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Users" ("Id", "Name", "PasswordHash") FROM stdin;
32cc8721-05a1-409f-8b7f-e0c4be555dc5	Nikita Golova	TestData
\.


--
-- Name: Recipes Id; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Recipes"
    ADD CONSTRAINT "Id" UNIQUE ("Id");


--
-- Name: Ingredients IngredientId; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Ingredients"
    ADD CONSTRAINT "IngredientId" UNIQUE ("Id");


--
-- Name: Favourites PK_Favourite; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Favourites"
    ADD CONSTRAINT "PK_Favourite" PRIMARY KEY ("UserId", "RecipeId");


--
-- Name: Ingredients PK_Ingredient; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Ingredients"
    ADD CONSTRAINT "PK_Ingredient" PRIMARY KEY ("Id");


--
-- Name: Recipes PK_Recipe; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Recipes"
    ADD CONSTRAINT "PK_Recipe" PRIMARY KEY ("Id");


--
-- Name: RecipeComments PK_RecipeComment; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RecipeComments"
    ADD CONSTRAINT "PK_RecipeComment" PRIMARY KEY ("Id", "UserId", "RecipeId");


--
-- Name: RecipeIngredients PK_RecipeIngredients; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RecipeIngredients"
    ADD CONSTRAINT "PK_RecipeIngredients" PRIMARY KEY ("IngredientId", "RecipeId");


--
-- Name: RecipeSteps PK_RecipeStep; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RecipeSteps"
    ADD CONSTRAINT "PK_RecipeStep" PRIMARY KEY ("Id", "RecipeId");


--
-- Name: RecipeStepComments PK_RecipeStepComment; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RecipeStepComments"
    ADD CONSTRAINT "PK_RecipeStepComment" PRIMARY KEY ("Id", "UserId", "StepId", "RecipeId");


--
-- Name: Scores PK_Score; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Scores"
    ADD CONSTRAINT "PK_Score" PRIMARY KEY ("UserId", "RecipeId");


--
-- Name: Users PK_User; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "PK_User" PRIMARY KEY ("Id");


--
-- Name: RecipeComments RecipeCommentId; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RecipeComments"
    ADD CONSTRAINT "RecipeCommentId" UNIQUE ("Id");


--
-- Name: RecipeStepComments RecipeStepCommentId; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RecipeStepComments"
    ADD CONSTRAINT "RecipeStepCommentId" UNIQUE ("Id");


--
-- Name: Users UserId; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "UserId" UNIQUE ("Id");


--
-- Name: Scores Relationship10; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Scores"
    ADD CONSTRAINT "Relationship10" FOREIGN KEY ("RecipeId") REFERENCES public."Recipes"("Id");


--
-- Name: RecipeSteps Relationship11; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RecipeSteps"
    ADD CONSTRAINT "Relationship11" FOREIGN KEY ("RecipeId") REFERENCES public."Recipes"("Id");


--
-- Name: RecipeStepComments Relationship12; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RecipeStepComments"
    ADD CONSTRAINT "Relationship12" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id");


--
-- Name: RecipeStepComments Relationship14; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RecipeStepComments"
    ADD CONSTRAINT "Relationship14" FOREIGN KEY ("StepId", "RecipeId") REFERENCES public."RecipeSteps"("Id", "RecipeId");


--
-- Name: RecipeIngredients Relationship2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RecipeIngredients"
    ADD CONSTRAINT "Relationship2" FOREIGN KEY ("IngredientId") REFERENCES public."Ingredients"("Id");


--
-- Name: RecipeIngredients Relationship3; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RecipeIngredients"
    ADD CONSTRAINT "Relationship3" FOREIGN KEY ("RecipeId") REFERENCES public."Recipes"("Id");


--
-- Name: RecipeComments Relationship5; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RecipeComments"
    ADD CONSTRAINT "Relationship5" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id");


--
-- Name: RecipeComments Relationship6; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RecipeComments"
    ADD CONSTRAINT "Relationship6" FOREIGN KEY ("RecipeId") REFERENCES public."Recipes"("Id");


--
-- Name: Favourites Relationship7; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Favourites"
    ADD CONSTRAINT "Relationship7" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id");


--
-- Name: Favourites Relationship8; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Favourites"
    ADD CONSTRAINT "Relationship8" FOREIGN KEY ("RecipeId") REFERENCES public."Recipes"("Id");


--
-- Name: Scores Relationship9; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Scores"
    ADD CONSTRAINT "Relationship9" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id");


--
-- PostgreSQL database dump complete
--

