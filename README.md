Challenge: The Water Jug Problem

Intro

This challenge was offered to me by ChicksGold for a technical interview for the position of backend programmer during a period of 3 days to develop it,
test it, document it and deliver it through this platform.

Description

This challenge consists of designing and developing a RESTful API that solves the classic water jug problem. 
Given a jug with capacity X and another with capacity Y, the task is to find the optimal sequence of steps to measure exactly Z liters of water.

Requirements

RESTful API: You must expose a POST endpoint to receive the input data and return the solution in JSON format.
Input Data:
x: Capacity of the first jug (positive integer).
y: Capacity of the second jug (positive integer).
z: Amount of water to measure (positive integer).
Output Data:
An array of objects, where each object represents a step and contains the action to be performed (fill, empty, pour).

Error Handling and Validation:

Validate the input to ensure that X, Y, and Z are positive integers.
Return meaningful error messages in JSON format if the inputs are invalid or if no solution can be found.

Technologies Used

.NET 8 and C#
Framework: The API is built using .NET 8, which is the latest version of the .NET platform, providing improvements in performance,
security, and modern features to build robust web applications.
Language: C# is used as the programming language for its strong typing, rich set of libraries, and integration with the .NET ecosystem.

Postman for API Testing

Purpose: Postman is used for testing the RESTful API endpoints to ensure they work correctly and efficiently under various conditions.
Features Used:
Request Collections: Organized groups of requests for easy testing of all endpoints.
Automated Testing: Set up tests to automatically verify response status codes, headers, and body content.
Environment Variables: Used to manage different configurations for development, testing, and production environments.
Response Time Tracking: Monitored the performance of API responses to ensure optimal speed.
_____________________________________________________________________________________________________________
Request
Method: POST

URL: /api/jug/solve

Headers: Content-Type: application/json

Body:

{
  "CapX": 2,
  "CapY": 10,
  "DesiredAmount": 4000
}

Response:
Status Code: 400 Bad Request

Body:

Desired amount cannot be greater than the sum of the capacities.
_________________________________________________________________________________________________________________
Request
Method: POST

URL: /api/jug/solve

Headers: Content-Type: application/json

Body:
{
  "CapX": 3,
  "CapY": 5,
  "DesiredAmount": 4
}
Response:
Status Code: 200 Ok

{
    "message": "Solvable",
    "steps": 6
}
_________________________________________________________________________________________________________________

Request
Method: POST

URL: /api/jug/solve

Headers: Content-Type: application/json

Body:
{
  "CapX": 3,
  "CapY": -5,
  "DesiredAmount": 4
}
Response:
Status Code: 400 Bad Request

Capacities must be positive integers greater than zero.
