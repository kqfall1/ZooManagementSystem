I am handing this assingment in several days late because I did not manage my time so well towards the end of this semester. However, I put
lots of effort into this application, so I would like to submit it even if it gets a 0%. One challenge I experienced in creating this 
application was implementing polymorphic serialization, which I have not been taught about. I also initially began using System.Text.Json, 
which does not support polymorphic serialization (if I'm not mistaken), so I eventually had to switch to Newtonsoft.Json. I put a lot of thought
into the seperation of concerns in regards to my classes and methods. I also made sure that my library classes are not error-prone by making 
most fields/properties/methods internal and only exposing fields/properties/methods that don't pose any risks. I learned a lot about Windows
Form applications from this project. All the event-handling methods get messy very quickly! Finally, I also learned more about how to choose
between fields and properties when designing a class. Properties are generally for pieces of data that are required to instansiate a class 
(for serialization purposes, because most serializer work better with properties than fields) and are expected to not require much overhead
to compute (if any computation is done at all). Fields are generally for pieces of data that don't even need to be serialized (although I am
fond of making some pieces of data for my classes that won't change into fields, such as names and ids. 