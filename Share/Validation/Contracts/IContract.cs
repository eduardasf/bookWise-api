﻿using Shared.Validation;

namespace Shared.FluentValidator.Validation
{
    public interface IContract
    {
        ValidationContract Contract { get; }
    }
}
