<div id="top"></div>

<br />
<div align="center">
  <a href="https://github.com/halilkoca/setur-assessment-backend-net">
    <img src="https://github.com/othneildrew/Best-README-Template/raw/master/images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Backend Net Readme</h3>
</div>



### Built With

This section list major frameworks/libraries used to bootstrap your project.

* [.Net 5](https://dotnet.microsoft.com/en-us/download)
* [RabbitMQ](https://www.rabbitmq.com/)
* [MongoDB](https://www.mongodb.com/)
* [Docker](https://www.docker.com/)
* [Automapper](https://github.com/AutoMapper/AutoMapper)
* [FluentValidation](https://fluentvalidation.net/)
* [Xunit](https://xunit.net/)

<p align="right">(<a href="#top">back to top</a>)</p>


## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

* Docker must installed on your system.
* Move into contacts folder after cloning the project.
* And then run this command:
* docker
  ```sh
  docker-compose up
  ```


And that's all.


## Usage of Contact.API

* http://localhost:5000/swagger/index.html

* [api/Contact/Get(BaseRequest request)](http://localhost:5000/api/Contact/Get) -> Get list of Contacts
* [api/Contact/Get(string id)](http://localhost:5000/api/Contact/Get) -> Get one contact
* [api/Contact/GetByName(string id)](http://localhost:5000/api/Contact/GetByName) -> Get one contact by name
* [api/Contact/Create(model)](http://localhost:5000/api/Contact/Create) -> Create one contact with contact informations
* [api/Contact/CreateBulk](http://localhost:5000/api/Contact/CreateBulk) -> Create bulk contacts
* [api/Contact/Update](http://localhost:5000/api/Contact/Update) -> Update one contact
* [api/Contact/Delete](http://localhost:5000/api/Contact/Delete) -> Delete one contact
* [api/Contact/DeleteBulk](http://localhost:5000/api/Contact/DeleteBulk) -> Delete bulk contacts

## Usage of Report.APi

* http://localhost:5001/swagger/index.html

* [api/Location/Generate()](http://localhost:5001/api/Location/Generate) -> Generate location report
* [api/Location/Get(string id)](http://localhost:5001/api/Location/Get) -> Get information about reports
* [api/Location/GetDetails(string id)](http://localhost:5001/api/Location/GetDetails) -> Get one report details

<p align="right">(<a href="#top">back to top</a>)</p>

## About The Project

[![Product Name Screen Shot][product-screenshot]](https://halilkoca.com)

<p align="right">(<a href="#top">back to top</a>)</p>

## License

Distributed under the Apache License 2.0. See `LICENSE.txt` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>

## Contact

Halil Koca - [@halil_koca](https://twitter.com/halil_koca)

Project Link: [https://github.com/halilkoca/setur-assessment-backend-net](https://github.com/halilkoca/setur-assessment-backend-net)

<p align="right">(<a href="#top">back to top</a>)</p>

[product-screenshot]: screenshot.jpg
