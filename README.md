# DietDiary
> Application for calculating calories and macronutrients with some additional features

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Features](#features)
* [Inspiration](#inspiration)

## General info
It's a consol application that allows user to calculate the calorific value and create meals for a selected day of the year. User can check the history of his meals and add meals and products to the database, which is xml file with some example products and meals. All funcionality is available in the _Features_ section.
This application is built in Clean Architecture - there are two layers - domain layer, where are all models and application layer, where services, interfaces and managers (to communicate with user) were implemented. There are also unit tests written in accordance with AAA pattern. 

## Technologies
* .NET Core 3.1.6
* LINQ
* Data format - XML
* FluentAssertions 5.10.3
* Moq 4.14.5
* Xunit 2.4.0
* Clean architecture
* Unit tests (AAA pattern)

## Features
* Counting the current calorific value and the selected day
* Adding / removing / updating products from the database
* Creating / removing / updating meals - adding them to the database and to the current day
* Recording the caloric value and macronutrients of the day and the past
* Reading all available products / meals / calories etc. as well as their details both on the selected date and from the database
* Recording body measurements
* Saving and reading current database from xml file while program is starting/ending

## Inspiration
The main goal of the project was to create a simple application thanks to which I would be able to quickly create meals for the whole day with a calorie summary.

