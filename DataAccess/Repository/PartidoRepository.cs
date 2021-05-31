using CommonSolution.DTO;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PartidoRepository
    {
        private JugadorMapper _JugadorMapper;
        private PartidoMapper _PartidoMapper;

        public PartidoRepository()
        {
            this._JugadorMapper = new JugadorMapper();
            this._PartidoMapper = new PartidoMapper();
        }


        public void agregarPartido(dtoPartido dto)
        {
            using (DBEntities context = new DBEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Partido nuevoPartido = this._PartidoMapper.toEntity(dto);
                        context.Partido.Add(nuevoPartido);
                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }

                }

            }

        }

        public dtoPartido GetPartidoById(long idPartido)
        {
            dtoPartido dto = null;
            using (DBEntities context = new DBEntities())
            {
                Partido nuevoPartido = context.Partido.AsNoTracking().FirstOrDefault(f => f.idPartido == idPartido);
                dto = this._PartidoMapper.toDto(nuevoPartido);
            }

            return dto;
        }

        public void ModificarPartido(dtoPartido dto)
        {
            using (DBEntities context = new DBEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Partido currPartido = context.Partido.FirstOrDefault(f => f.idPartido == dto.idPartido);

                        currPartido.idJugador1 = dto.idJugador1;
                        currPartido.idJugador2 = dto.idJugador2;
                        currPartido.idTorneo = dto.idTorneo;
                        currPartido.PuntosJugador1 = dto.PuntosJugador1;
                        currPartido.PuntosJugador2 = dto.PuntosJugador2;
                        currPartido.FechaHoraFin = dto.FechaHoraFin;
                        currPartido.FechaHoraInicio = dto.FechaHoraInicio;

                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }

                }

            }

        }

        public List<dtoPartido> GetPartidosTorneo(long idTorneo)
        {
            List<dtoPartido> colDto = null;
            using (DBEntities context = new DBEntities())
            {
                List<Partido> colPartidos = context.Partido.AsNoTracking().Where(f => f.idTorneo == idTorneo).ToList();
                colDto = this._PartidoMapper.toDto(colPartidos);
            }

            return colDto;
        }

        //E
        public List<dtoCantPartidosTorneo> GetPartidosPorTorneo()
        {
            List<dtoCantPartidosTorneo> colReporte = null;
            using (DBEntities context = new DBEntities())
            {
                colReporte = (from ped in context.Partido
                              where ped.FechaHoraFin != null
                              group ped by ped.idTorneo into grp
                              select new dtoCantPartidosTorneo
                              {
                                  idTorneo = grp.Key,
                                  cantidad = grp.Count()
                              }).ToList();
            }

            return colReporte;
        }



    }
}
