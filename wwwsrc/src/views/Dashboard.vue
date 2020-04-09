<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    <form @submit.prevent="addVault">
      <input type="text" placeholder="title" v-model="newVault.Name" required />
      <input type="text" placeholder="description" v-model="newVault.Description" />
      <button type="submit" title="Make new Vault" class="btn btn-primary btn-lg">+</button>
    </form>
    <div class="row">
      <Vault v-for="Vault in userVaults" :key="Vault.id" :vaultData="Vault" />
    </div>
  </div>
</template>

<script>
import Vault from "../components/Vault";
export default {
  name: "Dashboard",
  mounted() {},
  computed: {
    userVaults() {
      return this.$store.state.userVaults;
    }
  },
  components: {
    Vault
  },
  data() {
    return {
      newVault: {
        Name: "",
        Description: ""
      }
    };
  },
  methods: {
    addVault() {
      debugger;
      this.$store.dispatch("addVault", this.newVault);
      (newVault.Name = ""), (newVault.Description = "");
    }
  }
};
</script>

<style></style>
