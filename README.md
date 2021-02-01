# GoodCompanyDemo
This is a demo for a prospective employer. The brief was to create an inventory management system for computer infrastructure so that users could view and edit inventory information.

There was no real guidance as to how to build the interface. We were told we could ue an advanced framewor like Angular of Vue, or just do a simple html form.
As it happened I had been doing a lot of work around integrating SPA frameworks with .NET, si I decided to do an Angualar front-end with a webAPI backend.

Unfortunatley, despite having quite a lot of existing code to hand, there were quite a lot of chllenges involved in getting the application to work, and these ended up chewing up a lot of development time, so I coudl not implement everything I hoped to do.
Nonetheless, the fundamental technical challenges were solved, and any additional features would really just have been extensions of the same idea.

I wrote some server-side unit tests, but did not have time to write clien-side ones. I wasted a lot of time trying to get an integration test to work, only to comclude that there was nothing wrong with the code - it was just that the approach was unsuitable for testing unpublished SPA applications.

The major challenge was to support a variety of different computer types. I created a parent class that stored all common properties, and inherited from it for computers with more specific requirements.

That created a problem, though. I needed to know if I could communicate with the server backend by only specifying the parent class. This is known in the trade as "boxing" - you store an item as an instance of a more general class, or even in a generic container that does not have any knowlwdge of the class.
You then have to "unbox" - dynamically cast the object back to its specific class when you get a response. The worry I had was that I would find that my class parameters were truncated by the operation. I would only be able to get the parent class properties back, and the sub-class properties would be discarded by the POST operation.

I wrote a set of xunit unit tests to examine this issue, and was gratified to discover, from the point of view of .NET, that the boxing and unboxing operations worked. I assumed I had solved the issue. But it's a good example of how even a unit test can blind-sied you:
the same operation did not work when I invoked the service the the JS frontend. The truncation I had feared was very much in evidence. I also found it very difficult to POST to webAPI from the frontend, and ran into obscure issues relating to JSON serialisation. I had to install the Newtonsoft JSON parser to get the operation to work.

IN the end, the work-around was to create a cludgy generic class that contained every conceivable property, and then create child classes for storage by checking the typeName property.

Not the cool solution I had hoped for. If I had time, I woould have looked as just passing in an Object parameter, and then using a Factory method to spawn the required class, and using reflection to loop through the child class properties and map them onto whatever properties were populated in the Object.

I have experimented with Factory methods written in other languages like Java, but unfortunately some of the cool things you can do with template return types don't seem to work in C#, so the corresponding implementation in C# tends to be rather disapointing, involving a lot ao hard-coding of classes via switch statements that you might hop you could automate.

Another thing - you have to replicate ou classes in both the back-nd and front-end. It would be great if you could somehow spawn JS or TS classes from a .NET definition, but I can't see any obvious way of doing it.

A big annoyance to me with .NET is that because MS keep relasing new versions in less than a year, there's a huge amount of unreliable information floating around on the internet.
When I was having trouble capturing the POST parameter, some initial research I did led me to think my implementation was out-of-date. But then I realised it was the other way around. I was reading an old article, and it wasn't identifying the cause of my problem.

The Angular implementation is not going to win any prizes, but it's quite well written, and uses a good variety of techniques - service injection, some inheritance, routing, subscribing to Observables, refirecting, and reactive forms.

I didn't have time to look at modules, but it's probably too small a project to benefit from them. A major annoyance - the new Angular CLI is now module-aware by default and keeps crashing saying it can't find a suitable module to house your component when you try to create one.

There are other techniques like lazy-loading, but these are probably beyond the scope of a simple project like this. I could have used the Material library for databinding, but it would have been overkill.

One major annoyance was discovering that there is no built-in way of reading a select form control in Angular. You have to use a rather cludgy work-around triggered by the control's change event. That means yo have to hard-code the initial value of the control, which seems very limited, an makes it difficult to create the control dynamically from a service, which is what I was originally hoping to do.

