namespace NExtra.Geo.Abstractions
{
    /// <summary>
    /// This interface can be implemented by geo classes, that
    /// should be able to calculate the rhumb distance between
    /// two positions.
    /// </summary>
    public interface ICanCalculateRhumbDistance
    {
        /// <summary>
        /// Calculate the rhumb distance between two positions.
        /// </summary>
        /// <param name="position1">The source position.</param>
        /// <param name="position2">The target position.</param>
        /// <param name="distanceUnit">The type of distance to return.</param>
        /// <returns>The rhumb distance between the two positions.</returns>
        double CalculateRhumbDistance(Position position1, Position position2, DistanceUnit distanceUnit);
    }
}