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
        // WHAT I NEED TO DO:
        // I need to create an array that holds multiples of a given number.
        // For example, if someone gives me 7 and asks for 5 multiples,
        // I should give back {7, 14, 21, 28, 35}.
        //
        // HOW I'LL DO IT:
        //
        // Step 1: Create a new array with the exact size the user asked for
        //         - I use new double[length] to make an array with 'length' slots
        //         - Right now all slots are empty, I need to fill them
        //
        // Step 2: Use a for loop to go through each position in the array
        //         - The loop will run from i = 0 to i < length
        //         - Each time through the loop, i will be the current position
        //         - I use i as my position marker to track where I am in the array
        //
        // Step 3: For each position, calculate the correct multiple
        //         - The formula is: number * (i + 1)
        //         - I add 1 to i because the first multiple should be number * 1
        //         - Let me trace through an example to make sure this works:
        //           * When i = 0: number * (0 + 1) = number * 1 (first multiple)
        //           * When i = 1: number * (1 + 1) = number * 2 (second multiple)
        //           * When i = 2: number * (2 + 1) = number * 3 (third multiple)
        //         - This pattern continues until I've filled the whole array
        //
        // Step 4: Store each calculated multiple in the array at position i
        //         - This way, position 0 gets the first multiple
        //         - Position 1 gets the second multiple, and so on
        //         - I'm building the array from left to right
        //
        // Step 5: Return the completed array to whoever called this function
        //         - After the loop finishes, the array is completely filled
        //         - I return it so the caller can use the results
        //
        
        double[] result = new double[length];
        
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        
        return result;
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
        // WHAT I NEED TO DO:
        // I need to take the last 'amount' elements from a list and move them 
        // to the front, while keeping everything in the same order.
        // For example: {1,2,3,4,5,6,7,8,9} with amount = 3
        // Should become: {7,8,9,1,2,3,4,5,6}
        //
        // HOW I FIGURED THIS OUT:
        // I realized this is really just a "cut and paste" operation.
        // I need to cut the last few elements and paste them at the front.

        // MY STEP-BY-STEP APPROACH:
        // Step 1: Find where to make the cut
        //         - I calculate splitPoint = data.Count - amount
        //         - This tells me the index where the last 'amount' elements begin
        //         - For my example: data.Count = 9, amount = 3
        //           splitPoint = 9 - 3 = 6
        //           So elements at positions 6, 7, and 8 are the ones that will move
        //
        // Step 2: Save the elements I need to move
        //         - I use GetRange(splitPoint, amount) to make a copy
        //         - GetRange creates a new list with just those elements
        //         - I need to save them because I'm about to delete them
        //         - For my example: GetRange(6, 3) gives me {7, 8, 9}
        //         - I store these in a temporary list called 'lastElements'
        //
        // Step 3: Delete those elements from their original position
        //         - I use RemoveRange(splitPoint, amount) to remove them
        //         - After this, the list is shorter and only has the first part
        //         - For my example: RemoveRange(6, 3) removes {7, 8, 9}
        //           Now data = {1, 2, 3, 4, 5, 6}
        //
        // Step 4: Paste the saved elements at the very beginning
        //         - I use InsertRange(0, lastElements) to add them at position 0
        //         - Position 0 means "at the front of the list"
        //         - For my example: InsertRange(0, {7, 8, 9})
        //           Now data = {7, 8, 9, 1, 2, 3, 4, 5, 6}
        //
        // Step 5: The list is now fully rotated!
        //         - Notice that I don't return anything (void method)
        //         - This is because I modified the original list directly
        //         - The caller will see the changes because they have the same list
        int splitPoint = data.Count - amount;
        List<int> lastElements = data.GetRange(splitPoint, amount);
        data.RemoveRange(splitPoint, amount);
        data.InsertRange(0, lastElements);
    }
}