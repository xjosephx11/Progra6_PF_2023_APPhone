using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Progra6_PF_2023_APPhone.Models;

namespace Progra6_PF_2023_APPhone.ViewModels
{
    public class UserWiewModel : BaseViewModel
    {
        public Usuario MyUser { get; set; }
        public UsuarioRol MyUserRole { get; set; }

        public UserWiewModel() 
        {
            MyUser = new Usuario();
            MyUserRole = new UsuarioRol();
        }

        public async Task<bool> UserAccessValidation(string pEmail, string pPassword) 
        {
            if (IsBusy) return false;
            
            IsBusy = true;

            try
            {
                MyUser.Email = pEmail;
                MyUser.Contrasenia = pPassword;

                bool R = await MyUser.ValidateUserLogin();
                return R;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<List<UsuarioRol>> GetUserRolesAsync() 
        {
            try
            {
                List<UsuarioRol> roles = new List<UsuarioRol>();
                roles = await MyUserRole.GetAllUserRoleAsync();
                if (roles == null)
                {
                    return null;
                }
                return roles;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //funcion de creacion de usuario nuevo
        public async Task<bool> AddUserAsync(string pEmail,
                                                string pPassword,
                                                string pName,
                                                string pBackupEmail,
                                                string pPhoneNumber,
                                                string pAddress,
                                                int pUserRoleID) 
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser = new Usuario();
                MyUser.Email = pEmail;
                MyUser.Contrasenia = pPassword;
                MyUser.Nombre = pName;
                MyUser.BackupEmail = pBackupEmail;
                MyUser.Numero = pPhoneNumber;
                MyUser.Addres = pAddress;
                MyUser.UsuarioRolId = pUserRoleID;

                bool R = await MyUser.AddUserAsync();
                return R;
            }
            catch (Exception)
            {

                throw;
            }
            finally { IsBusy = false; }
        }






    }
}
