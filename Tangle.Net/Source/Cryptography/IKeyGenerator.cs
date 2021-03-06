﻿namespace Tangle.Net.Source.Cryptography
{
  using Tangle.Net.Source.Entity;

  /// <summary>
  /// The KeyGenerator interface.
  /// </summary>
  public interface IKeyGenerator
  {
    #region Public Methods and Operators

    /// <summary>
    /// The get key for.
    /// </summary>
    /// <param name="address">
    /// The address.
    /// </param>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    IPrivateKey GetKeyFor(Address address);

    #endregion
  }
}