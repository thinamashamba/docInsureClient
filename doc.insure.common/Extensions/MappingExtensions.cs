using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doc.insure.common.Extensions
{
    public static class MappingExtensions
    {
        public static R Map<T, R>(this T model)
        {
            Mapper.CreateMap<T, R>();
            return Mapper.Map<R>(model);
        }

        //public static R Map<T, R, S, D>(this T model)
        //{
        //    Mapper.CreateMap<IEnumerable<S>, IEnumerable<D>>();
        //    Mapper.CreateMap<T, R>();
        //    return Mapper.Map<R>(model);
        //}

        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> models)
        {
            Mapper.CreateMap<IEnumerable<T>, IEnumerable<R>>();
            return Mapper.Map<IEnumerable<R>>(models);
        }
    }
}
