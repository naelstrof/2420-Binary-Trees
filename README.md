#Trees

| *Due* Wednesday by 11:59pm | *Points* 10 | *Submitting* a file upload | *File Types* zip |

[Video](https://utah.instructure.com/courses/351899/files/51209376/download?wrap=1)
[Expression Trees](https://utah.instructure.com/courses/351899/files/51369971/download?wrap=1)

* Coder – 60%
  1. Write a BinarySearchTree class with an Add(int item) and Contains(int item). 
  2. Write an ExpressionParser class that will convert any given expression into an ExpressionTree class instance. The ExpressionParser must take a string such as “5 + 2 * 8 – 6 / 4” and convert it into an ExpressionTree. String has a Split() method which you will find quite helpful.
* Programmer - 80%
  1. Write a TraversePre(), TraverseIn(), and TraversePost() for both the BinarySearchTree class and the ExpressionTree class. These return the contents of your tree in a concatenated string using a pre-order traversal, an in-order traversal, and a post-order traversal. Description here: https://en.wikipedia.org/wiki/Tree_traversal%23Pre-order
  2. Write an Evaluate() function on your ExpressionTree that calculates the value of your expression.
* Engineer – 90%
  1. Write test code for all code in your assignment (including the Google Engineer code if you complete that section of the assignment).
  2. Testing hints: When testing your expression evaluation, I would expect you to assert that the result of your expression evaluation is equal to the same result as what the C# compiler calculates as well. Also, compare the result of the tree traversals to a string literal containing the correct result of the respective traversal.
* Google Engineer – 100%
  1. Instead of storing ints in your BinarySearchTree, store any generic T type instead.
  2. Use T’s IComparable interface to do the comparision instead of the < operator.
  3. Allow the user to pass an IComparer to the BinarySearchTree constructor to use in place of the IComparable functionality.
