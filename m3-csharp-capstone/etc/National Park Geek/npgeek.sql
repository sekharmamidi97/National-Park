create table park
(
	parkCode varchar(10) not null,
	parkName varchar(200) not null,
	state varchar(30) not null,
	acreage int not null,
	elevationInFeet int not null,
	milesOfTrail real not null,
	numberOfCampsites int not null,
	climate varchar(100) not null,
	yearFounded int not null,
	annualVisitorCount int not null,
	inspirationalQuote varchar(max) not null,
	inspirationalQuoteSource varchar(200) not null,
	parkDescription varchar(max) not null,
	entryFee int not null,
	numberOfAnimalSpecies int not null,

	constraint pk_park primary key (parkCode)
);

CREATE TABLE weather
(
	parkCode varchar(10) not null,
	fiveDayForecastValue int not null,
	low int not null,
	high int not null,
	forecast varchar(100) not null,

	constraint pk_weather primary key (parkCode, fiveDayForecastValue),
	constraint fk_weather_park foreign key (parkCode) references park (parkCode)

);

CREATE TABLE survey_result
(
	surveyId int identity(1,1) not null,
	parkCode varchar(10) not null,
	emailAddress varchar(100) not null,
	state varchar(30) not null,
	activityLevel varchar(100) not null,
	
	constraint pk_survey_result primary key (surveyId)
);




INSERT INTO weather VALUES ('GNP',1,27,40,'snow');
INSERT INTO weather VALUES ('GNP',2,31,43,'snow');
INSERT INTO weather VALUES ('GNP',3,28,40,'partly cloudy');
INSERT INTO weather VALUES ('GNP',4,24,34,'cloudy');
INSERT INTO weather VALUES ('GNP',5,25,32,'snow');
INSERT INTO weather VALUES ('GCNP',1,35,66,'sunny');
INSERT INTO weather VALUES ('GCNP',2,34,69,'partly cloudy');
INSERT INTO weather VALUES ('GCNP',3,32,57,'rain');
INSERT INTO weather VALUES ('GCNP',4,34,62,'sunny');
INSERT INTO weather VALUES ('GCNP',5,31,62,'partly cloudy');
INSERT INTO weather VALUES ('GTNP',1,27,46,'cloudy');
INSERT INTO weather VALUES ('GTNP',2,30,49,'partly cloudy');
INSERT INTO weather VALUES ('GTNP',3,31,46,'rain');
INSERT INTO weather VALUES ('GTNP',4,28,41,'rain');
INSERT INTO weather VALUES ('GTNP',5,22,38,'snow');
INSERT INTO weather VALUES ('MRNP',1,23,30,'snow');
INSERT INTO weather VALUES ('MRNP',2,24,32,'snow');
INSERT INTO weather VALUES ('MRNP',3,21,27,'snow');
INSERT INTO weather VALUES ('MRNP',4,23,27,'snow');
INSERT INTO weather VALUES ('MRNP',5,21,25,'snow');
INSERT INTO weather VALUES ('GSMNP',1,58,70,'partly cloudy');
INSERT INTO weather VALUES ('GSMNP',2,56,70,'thunderstorms');
INSERT INTO weather VALUES ('GSMNP',3,56,74,'cloudy');
INSERT INTO weather VALUES ('GSMNP',4,53,68,'thunderstorms');
INSERT INTO weather VALUES ('GSMNP',5,52,66,'thunderstorms');
INSERT INTO weather VALUES ('ENP',1,70,82,'partly cloudy');
INSERT INTO weather VALUES ('ENP',2,70,81,'partly cloudy');
INSERT INTO weather VALUES ('ENP',3,70,81,'partly cloudy');
INSERT INTO weather VALUES ('ENP',4,71,82,'thunderstorms');
INSERT INTO weather VALUES ('ENP',5,70,85,'sunny');
INSERT INTO weather VALUES ('YNP',1,23,43,'cloudy');
INSERT INTO weather VALUES ('YNP',2,26,47,'partly cloudy');
INSERT INTO weather VALUES ('YNP',3,25,44,'sunny');
INSERT INTO weather VALUES ('YNP',4,21,37,'snow');
INSERT INTO weather VALUES ('YNP',5,16,36,'snow');
INSERT INTO weather VALUES ('YNP',1,34,51,'partly cloudy');
INSERT INTO weather VALUES ('YNP',2,25,39,'snow');
INSERT INTO weather VALUES ('YNP',3,29,40,'sunny');
INSERT INTO weather VALUES ('YNP',4,32,38,'snow');
INSERT INTO weather VALUES ('YNP',5,23,34,'snow');
INSERT INTO weather VALUES ('CVNP',1,38,62,'rain');
INSERT INTO weather VALUES ('CVNP',2,38,56,'partly cloudy');
INSERT INTO weather VALUES ('CVNP',3,51,66,'partly cloudy');
INSERT INTO weather VALUES ('CVNP',4,55,65,'rain');
INSERT INTO weather VALUES ('CVNP',5,53,69,'thunderstorms');
INSERT INTO weather VALUES ('RMNP',1,30,47,'sunny');
INSERT INTO weather VALUES ('RMNP',2,35,55,'sunny');
INSERT INTO weather VALUES ('RMNP',3,34,50,'partly cloudy');
INSERT INTO weather VALUES ('RMNP',4,33,47,'partly cloudy');
INSERT INTO weather VALUES ('RMNP',5,30,43,'rain');