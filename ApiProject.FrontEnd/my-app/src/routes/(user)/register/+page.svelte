<script lang ="ts">
    /** @type {import('./$types').PageData} */

    import { enhance } from '$app/forms';
    import { fade } from 'svelte/transition';
    import {successfullyRegistered} from '../../../store'
    import Layout from '../+layout.svelte';
    export let form;
    let value = successfullyRegistered
</script>
<div class="login-form">
        <form
        method="POST"
        use:enhance={() => {
            return async ({ update }) => {
        await update({ reset: false });
    };
  }}
>
        <label for="firstName">Име:</label>
        <input type="text" name="firstName"  autocomplete="off" required title="Пишете на кирилица!" pattern="^[А-Яа-яЁё\s]+$" />
        <label for="secondName">Презиме:</label>
        <input type="text" name="secondName" autocomplete="off" required  title="Пишете на кирилица!" minlength =3 pattern="^[А-Яа-яЁё\s]+$"/>
        <label for="lastName">Фамилия:</label>
        <input type="text" name="lastName" autocomplete="off" required minlength ="3" pattern="^[А-Яа-яЁё\s]+$"/>
        <label for="email">E-mail:</label>
        <input type="email" name="email" autocomplete="off" required minlength ="3"/>
        <label for="personalId">ЕГН:</label>
        <input  inputmode="numeric" name="personalId" autocomplete="off"  required  size="10"/>
        <label for="personalId">Телефон:</label>
        <input  inputmode="numeric" name="phone" autocomplete="off"  required minlength ="10" size="12" maxlength="12" />
        <button type="submit">Влез</button>
        {#if form?.error}
            <div transition:fade={{ delay: 250, duration: 300 }} class="notice-error fadein ">
            {form.error}
            </div>
        
        {/if}
    </form>
</div>


<style>
    .notice-error{
        padding: 10px;
        margin-top: 10px;
        background-color: darkred;
        color: white;
    }
    .login-form {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
        padding: 20px;
        box-sizing: border-box;
        background-color: white;
    }

    form {
        width: 100%;
        max-width: 400px;
        padding: 40px;
        background-color: white;
        border-radius: 10px;
        box-shadow: 0px 0px 10px 0px rgba(0,0,0,0.1);
    }

    label {
        font-size: 18px;
        margin-bottom: 10px;
        display: block;
        color: black;
        font-family: Arial, Helvetica, sans-serif;
    }

    input {
        width: 100%;
        padding: 10px;
        font-size: 16px;
        border-radius: 5px;
        border: 1px solid #8899a6;
        margin-bottom: 20px;
        background-color: #253341;
        color: #fff;
    }

    button {
        width: 100%;
        padding: 10px;
        border: none;
        border-radius: 5px;
        background-color: #004080;
        color: #fff;
        font-size: 18px;
        cursor: pointer;
    }


    @media (max-width: 600px) {
        form {
            padding: 20px;
        }
    }
</style>