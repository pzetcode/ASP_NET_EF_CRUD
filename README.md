## Project idea
Main target was to reproduce scaffolded CRUD ASP.NET MVC interface (based on EF 6.x) in "manual" way - it means, to create all related functionality from scratch.
But, to make things bit different, solution is implemented on ASP.NET Web Forms.

#### Repro steps of development process:
- created empty ASP.NET Web Forms project
- created essential parts like Site.Master, Sitemap, CSS
- created "offline" edmx database with some sample rows related to cars
- added EF 6.x
- UI is very basic

#### Project details - by menu items:
- Default page

- DB Show data (WebGrid): it is just WebGrid component with paging and sorting to browse db content.

- DB CRUD (GridView): actual CRUD interface, based on GridView component.
   Related methods: carsGrid_GetData, carsGrid_UpdateItem, carsGrid_DeleteItem.
   To insert new record. click "Add new car".
   At this stage I've needed to add DynamicDataTemplatesCS package. Default_Insert.ascx.cs was modified later on to skip "Id" column (primary key in db, identity, auto-incremented).

- Search for car: basic search ("Factory" only)
    
- Add new car: described above. Date format for "Model year": MM/YYYY.

- Import XML file: import data to db using client XML file - see sample file: [sampleData.xml](https://github.com/pzetcode/DemoProject/blob/master/sampleData.xml).
   LINQ to XML was used to process import.

- Export db content: export whole db content into client machine using XML serialization.
   Export filename format: dd_MM_yyyy_HH_mm_ss_export.xml.
   Exported file can be used as a source for import.

## Reference
[Model Binding and Web Forms](https://docs.microsoft.com/en-us/aspnet/web-forms/overview/presenting-and-managing-data/model-binding/)
