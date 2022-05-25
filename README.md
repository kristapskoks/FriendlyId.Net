# FriendlyId.Net
FriendlyId implementation in c# based on  [Java](https://github.com/Devskiller/friendly-id) version

What is the FriendlyID library?
--
The FriendlyID library converts a given Guid (with 36 characters) to a URL-friendly ID (a "FriendlyID") which is based on Base62 (with a maximum of 22 characters), as in the example below:


    Guid                                        Friendly ID
    
    c3587ec5-0976-497f-8374-61e0c2ea3da5   ->   5wbwf6yUxVBcr48AMbz9cb
    |                                           |                              
    36 characters                               22 characters or less

In addition, this library allows to:
 

* convert from a FriendlyID back to the original Guid; and
* create a new, random FriendlyID

Why use a FriendlyID?
--
Globally  Unique IDs (Guids) provide a non-sequential and unique identifier that can be generated separately from the source database. As a result, it is not possible to guess either the previous or next identifier. That's great, but, to achieve this level of security, a Guid is long (128 bits long) and looks ugly (36 alphanumeric characters including four hyphens which are added to make it easier to read the Guid), as in this example: `123e4567-e89b-12d3-a456-426655440000`.

Such a format is:

* difficult to read (especially if it is part of a URL)
* difficult to remember
* cannot be copied with just two mouse-clicks (you have to select manually the start and end positions)
* can easily become broken across lines when it is copied, pasted, edited, or sent.


 FriendlyID C# library solves these problems by converting a given Guid using Base62 with alphanumeric characters in the range [0-9A-Za-z] into a FriendlyId which consists of a maximum of 22 characters (but in fact often contains fewer characters).


## Usage

```
// convert friendly id to Guid
var guid = FriendlyId.ToGuid("5wbwf6yUxVBcr48AMbz9cb");
// c3587ec5-0976-497f-8374-61e0c2ea3da5

// convert Guid to friendly id
var friendlyId = FriendlyId.ToFriendlyId(Guid.Parse("c3587ec5-0976-497f-8374-61e0c2ea3da5"));
// 5wbwf6yUxVBcr48AMbz9cb

//generate new friendly id
var friendlyId = FriendlyId.CreateFriendlyId();
```

