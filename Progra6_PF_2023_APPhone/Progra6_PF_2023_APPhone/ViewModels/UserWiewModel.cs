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
        public UserDTO MyUserDTO { get; set; }

        public UserWiewModel() 
        {
            MyUser = new Usuario();
            MyUserRole = new UsuarioRol();
            MyUserDTO = new UserDTO();
        }

        public async Task<UserDTO> GetUserDataAsync(string pEmail)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                UserDTO userDto = new UserDTO();
                UserDTO userDTO= await MyUserDTO.GetUserInfo(pEmail);
                if (userDTO == null) return null;
                return userDTO;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }
        }

        public async Task<bool> UpdateUser(UserDTO pUser)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyUserDTO = pUser;

                bool R = await MyUserDTO.UpdateUserAsync();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
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
