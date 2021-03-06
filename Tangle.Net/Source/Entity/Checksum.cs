﻿namespace Tangle.Net.Source.Entity
{
  using System;

  using Tangle.Net.Source.Cryptography;

  /// <summary>
  /// The checksum.
  /// </summary>
  public class Checksum : TryteString
  {
    #region Constants

    /// <summary>
    /// The length.
    /// </summary>
    public new const int Length = 9;

    #endregion

    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="Checksum"/> class.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    public Checksum(string value)
      : base(value)
    {
      if (value.Length != Length)
      {
        throw new ArgumentException("Checksum must be of length " + Length);
      }
    }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The from address.
    /// </summary>
    /// <param name="address">
    /// The address.
    /// </param>
    /// <returns>
    /// The <see cref="Checksum"/>.
    /// </returns>
    public static Checksum FromAddress(Address address)
    {
      var addressTrits = Converter.TrytesToTrits(address.Value);

      var kerl = new Kerl();
      kerl.Absorb(addressTrits);

      var checksumTrits = new int[Kerl.HashLength];
      kerl.Squeeze(checksumTrits);

      var tritsToTrytes = Converter.TritsToTrytes(checksumTrits);
      var checksum = tritsToTrytes.Substring(81 - Length, Length);

      return new Checksum(checksum);
    }

    #endregion
  }
}