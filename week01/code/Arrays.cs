using System.Numerics;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        /*  Plan for MultiplesOf Method:
         1. Function Definition: Create a public static method named MultiplesOf that returns a double[]. It will accept two parameters: an int number for the base value and an int length for the number of multiples to generate.
         2. Input Validation: Check if length is negative. This is an invalid argument, so we should throw an ArgumentOutOfRangeException.
         3. Handle Zero length: If length is zero, the result should be an empty array. We can return [] or System.Array.Empty<double>() for efficiency.
         4. Array Initialization: Create a new double array with a size equal to length.
         5. Population Loop: Iterate from 0 to length - 1. In each iteration, calculate the multiple. For an index i, the multiple will be number * (i + 1).
         6. Assigment: Assign the calculated multiple to the corresponding index in the array.
         7. Return Value: After the loop completes, return the newly populated array.
         */

        // Step 1: Define the function signature.
        // The function is public, static, named MultiplesOf, accepts two integers
        // 'number' and 'length', and returns a double array.

        // Step 2: Handle invalid input.
        // If 'length' is negative, it's an impossible request. Throw an exception
        // to signal that the calling code has provided an invalid argument.
        if (length < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length), "length cannot be negative.");
        }

        // Step 3: Handle the zero-length case.
        // If zero multiples are requested, return an empty array immediately.
        if (length == 0)
        {
            return [];
        }

        // Step 4: Initialize the result array with the required size.
        var multiples = new double[length];

        // Step 5-7: Loop 'length' times, calculate each multiple, and store it.
        for (int i = 0; i < length; i++)
        {
            // The multiple is the base number times the current position (1-based).
            multiples[i] = number * (i + 1);
        }

        // Step 8: Return the populated array.
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        /*  Plan for RotateListRight Method:
         1. Handle Edge Cases: First, I'll check for conditions where a rotation is either not possible or has no effect. This includes if the data list is null, if it contains one or fewer elements, or if the rotation amount is not positive. In these scenarios, the method can exit immediately.
         2. Normalize the Rotation Amount: A rotation can be cyclical. For instance, rotating a list of 9 items by 9 positions results in the same list. To handle this and amounts larger than the list's size, I will use the modulo operator (%). The actual number of positions to rotate will be amount % data.Count. If the result is 0, no rotation is needed, and the function can exit.
         3. Perform the Rotation using Slicing: The most straightforward way to perform the rotation on a List<T> is by "slicing" it.
         then:
         3.1. I'll identify the block of elements at the end of the list that needs to be moved to the front. The size of this block is the effectiveAmount calculated in the previous step.
         3.2. I will use GetRange() to copy this block of elements into a temporary list.
         3.3. Next, I'll use RemoveRange() to remove that same block from the end of the original list.
         3.4. Finally, I'll use InsertRange() to place the elements from the temporary list at the beginning of the original list, completing the rotation.
         */

        // Step 1: Handle edge cases.
        // If the list is null, empty, or has only one element, or if the amount
        // to rotate by is zero or negative, there's nothing to do.
        if (data == null || data.Count <= 1 || amount <= 0)
        {
            return;
        }

        // Step 2: Normalize the rotation amount.
        // Rotating by data.Count is a full circle, resulting in no change.
        // We only care about the remainder.
        int effectiveAmount = amount % data.Count;

        // If the effective amount is 0 after the modulo operation, no rotation is needed.
        if (effectiveAmount == 0)
        {
            return;
        }

        // Step 3: Slice the list and perform the rotation.
        int startIndex = data.Count - effectiveAmount;
        List<int> rotatedPart = data.GetRange(startIndex, effectiveAmount);
        data.RemoveRange(startIndex, effectiveAmount);
        data.InsertRange(0, rotatedPart);
    }
}
