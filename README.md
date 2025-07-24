# TaskManagementAPI

For this project I've used Sqlite so that anyone can just run the project without any further database configuration needed.
You can use postman or any rest api testing tool.  
The application follows a clean architecture pattern were the core business logic (Services in the context of this project) is self contained and has no concept of databases or other external mechanisms that does the actual operations. It's main focus is to satisfy whatever business logic the domain needs.  
If you have any further questions please let me know. You can contact me on my email elmoe01@gmail.com just in case you have difficulty reaching me on onlinejobs.

The following endpoints are available:

- Query a single task - GET api/tasks/{id}

Sample request  
GET https://localhost:44397/api/tasks/3

Sample response
```
{
  "Id": 1,
  "Title": "sample string 2",
  "Description": "sample string 3",
  "Status": "sample string 4",
  "CreatedAt": "2025-07-24T21:18:46.8850755+08:00"
}
```

- Update a task - PUT api/tasks/{id}	

Sample request  
PUT https://localhost:44397/api/tasks/8

Sample body
```
{
  "Title": "sample string 1",
  "Description": "sample string 2",
  "Status": "sample string 3"
}
```
Response code of 204 with no body

- Delete a task - DELETE api/tasks/{id}

Sample request  
DELETE https://localhost:44397/api/tasks/8

Response code of 204 with no body

- Query all tasks by status - GET api/tasks/status/{status}	

Sample request  
GET https://localhost:44397/api/tasks/status/INPROGRESS

Sample response
```
[
    {
        "Id": 8,
        "Title": "Delta",
        "Description": "Delta mission briefing.",
        "Status": "INPROGRESS",
        "CreatedAt": "2025-07-24T20:12:10.9859891"
    }
]
```

- Query all tasks - GET api/Tasks	

Sample request  
GET https://localhost:44397/api/tasks

Sample response
```
[
    {
        "Id": 1,
        "Title": "Buy groceries.",
        "Description": "Buy some groceries.",
        "Status": "TODO",
        "CreatedAt": "2025-07-23T16:23:19.12"
    },
    {
        "Id": 4,
        "Title": "Another task",
        "Description": "Pick the oranges from section Alpha.",
        "Status": "TODO",
        "CreatedAt": "2025-07-24T16:36:31.2565108"
    }
]
```

- Create a task - POST api/Tasks

Sample request  
POST https://localhost:44397/api/tasks

Response code of 204 with no body