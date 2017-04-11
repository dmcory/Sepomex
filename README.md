# [Sepomex](https://github.com/dmcory/sepomex) 
Sepomex is the acronym of mexican postal service (SErvicio POstal MEXicano).

This is an unnoficial REST API version of the database they bring to the [internet](http://www.sepomex.gob.mx/lservicios/servicios/CodigoPostal_Exportar.aspx).

## Contents
- [Setup](#setup)
- [How to Query](#how-to-query)
- [Contributing](#contributing)
- [Mole Masters](#mole-masters)
- [To-do List](#to-do-list)

## Setup
- Visual Studio
- Internet (to download the packages from nuget)

Open the Project in Visual Studio and run the following command in the Package Manager Console.
```
PM > Update-Database -Verbose
```

And that's it!

The total number of records stored in the database is `148,286` (April 2017) and it will take 7-10 seconds to complete.

## How to Query
When you run the project it will open the home of the website (the default one), in order to use it you need to add to the end of the URI:
```
/api/zip_codes
```

or you can use
```
/api/zip_codes/83293
```

if you are looking for the cities that match the current zip code.

## Contributing
If you want to contribute or have an idea to make this api better, please create another branch.

## Mole Masters
+ [Dark Mystical Cory](http://twitter.com/dmcory)

## To-do List
- Paginate the results
- Add cities and states to query

or tell me and i will add it!
