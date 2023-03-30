<h1>🔗 Somiod 🔗</h1>

<div style="border: 1px solid black; padding: 10px;">
<p>This project was developed as part of the <strong>Systems Integration</strong> course in the Computer Science and Engineering degree during the academic year 2022/2023.
<h1>Collaborators:</h1>
<ul>
<li><a href="https://github.com/sfilipa">Sara</a></li>
<li><a href="https://github.com/andrepintoo">André</a></li>
<li><a href="https://github.com/Yunikyon">Ana</a></li>
<li><a href="https://github.com/ivoafonsobispo">Ivo</a></li>
</ul>
<h1>Project Description:</h1>
This project aims to address the issue of interoperability and data sharing across different IoT devices, applications, and platforms. The current state of IoT solutions relies heavily on private protocols and cloud services, resulting in what researchers refer to as "SILO OF THINGS." To combat this issue, we propose a service-oriented middleware that provides a uniform method of accessing, writing, and notifying data, regardless of the application domain. Our middleware promotes interoperability and open data, enabling anyone to access data and develop new applications and services following the same format.
<br><br>
Our middleware is based on Web Services and a Web-based resource structure that adheres to Web open standards. The middleware's REST API provides a unique URL structure to access different resources, including application, module, data, and subscription resources. Each resource has a unique ID, name, creation date, and parent if applicable. The middleware supports multiple applications, each containing one or more modules, and each module contains data records. Subscription resources enable notifications for data records' creation or deletion events and require an MQTT endpoint to receive notifications.
<br><br>
All transferred and stored data follow the XML format, and the middleware persists resources and their data on a database. Our project's testing application involves controlling a light bulb through desktop or web applications. Creating a new application resource called Lighting and a related module resource called light_bulb will enable this control. The mobile app creates the light_command module resource and uses a subscription to turn the light bulb on or off by creating data records in the light_bulb module.
<br><br>
Overall, our middleware project aims to enhance the IoT concept's potential by promoting data interoperability, accessibility, and open data, allowing for more innovation in IoT applications and services.
<br><br>
<p>&#8702; <a href="https://github.com/sfilipa/somiod-is-ipleiria/blob/main/Projecto_Enunciado_2022-2023_Final.pdf">Project Statement</a></p>
<p>&#8702; <a href="https://github.com/sfilipa/somiod-is-ipleiria/blob/main/IS_Project_ReportTemplate_2022-2023.pdf">Report</a></p>
<h1>Tools Used</h1>
<ul>
<li>C#: Used for developing the application logic and functionality.</li>
<li>.NET Frameworks: Used as the platform for developing the application.</li>
<li>Visual Studio: Used as the integrated development environment for writing and testing the code.</li>
</ul>

<h1>Other Information</h1>
<ul>
  <li><strong>Our project received a grade of 16,72 out of 20.</strong></li>
  <li>This project was developed for the <a href="https://www.ipleiria.pt/curso/licenciatura-em-engenharia-informatica/" rel="nofollow">Computer Engineering degree</a> at <a href="https://www.ipleiria.pt" rel="nofollow">Polytechnic of Leiria</a></li>
</ul>
<p><a href="https://www.ipleiria.pt/estg/" rel="nofollow"><img src="https://camo.githubusercontent.com/f11c2f47a7221ed3eb4c80f84fe7c67414e23377aff6c6af3182c88624fbbbea/68747470733a2f2f7777772e69706c65697269612e70742f6e6f726d617367726166696361732f77702d636f6e74656e742f75706c6f6164732f73697465732f38302f323031372f30392f657374675f682d30312e6a7067" width="300" alt="Escola Superior de Tecnologia e Gestão" title="Escola Superior de Tecnologia e Gestão" data-canonical-src="https://www.ipleiria.pt/normasgraficas/wp-content/uploads/sites/80/2017/09/estg_h-01.jpg" style="max-width: 100%;"></a></p>
</div>
