# What it is?
AlterTank_Backend repository contains server section solution to AlterTank mobile application, written for engineering thesis needs. 


## Technologies
* EntityFramework
* PostgreSql database
* ASP .NET

## Method List
* Http GET GetInRange - Method that returns a list of stations that meet the criteria within the specified range from the user location.
* Http GET GetAll - Method that returns a list of stations that meet the user criteria.
* Http PUT CreateStation - Method allowing users to save new place into server database.
* Http PUT AddPlug - Method providing opportunity to users to edit existing place by adding new fueling "plug".
* Http PUT AddPrice - Method providing opportunity to users to report price of fuel on speciffic station.
