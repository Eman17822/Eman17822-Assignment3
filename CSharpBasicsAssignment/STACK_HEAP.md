using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpBasicsAssignment
{
    class STACK_HEAP
    {# Stack vs Heap in C#

## Example 1: Creating an Order object

Code:

Order o1 = new Order
{
    OrderId = 1,
    CustomerName = "Ali"
};


Diagram:

STACK                         HEAP
+------------------+          +----------------------+
| o1               | -------> | Order object         |
| Reference        |          | OrderId = 1          |
+------------------+          | CustomerName = "Ali" |
                              +----------------------+

Explanation:

* `o1` is a reference variable.
* The `new` keyword creates an Order object.
* The reference points to the created object.

## Example 2: Copying the reference

Code:


Order o2 = o1;

Diagram:


STACK                         HEAP
+------------------+          +----------------------+
| o1               | -------> | Order object         |
+------------------+     +--> | OrderId = 1          |
| o2               | ----+     | CustomerName = "Ali" |
+------------------+          +----------------------+

Explanation:

* `o2 = o1` copies the reference, not the object.
* Both variables refer to the same Order object.
* No new Order object is created by this assignment.

## Example 3: Changing the object through o2

Code:


o2.IsPaid = true;


Diagram:

STACK                         HEAP
+------------------+          +----------------------+
| o1               | -------> | Order object         |
+------------------+     +--> | OrderId = 1          |
| o2               | ----+     | CustomerName = "Ali" |
+------------------+          | IsPaid = true        |
                              +----------------------+

Explanation:

* `o1` and `o2` refer to the same object.
* Changing the object through `o2` is visible when accessing it through `o1`.
* Therefore, `o1.IsPaid` is also `true`.

## Value Types vs Reference Types

* A value type, such as `int` or a `struct`, stores its value directly in the variable.
* Copying a value type creates an independent copy of its value.
* A reference type, such as a `class`, uses a reference to access an object.
* Copying a reference does not create a new object; both references can point to the same object.

Note: These diagrams are simplified conceptual illustrations of memory. The exact physical placement of variables and objects depends on the runtime and execution context.

    }
}
