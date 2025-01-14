﻿using E = EksiSozlukAPI.Domain.Entities;

namespace EksiSozlukAPI.Application.Repositories.Entry
{
    public interface IEntryReadRepository : IReadRepository<E.Entry>
    {
        List<E.Entry> GetEntryListByTitleId(int pageNumber, int pageSize, int titleId);
    }
}
