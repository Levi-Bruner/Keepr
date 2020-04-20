<template>
  <div class="dashboard">
    <h1 class="text-center">DASHBOARD</h1>
    <h3 class="text-center">Make a new Vault</h3>
    <form class="text-center" @submit.prevent="addVault">
      <ul style="list-style-type:none">
        <li>
          <input type="text" placeholder="title" v-model="newVault.Name" required />
        </li>
        <li>
          <input type="text" placeholder="description" v-model="newVault.Description" />
        </li>
        <li>
          <button type="submit" title="Make new Vault" class="btn btn-primary btn-lg">+</button>
        </li>
      </ul>
    </form>

    <h3 class="text-center">My Vaults</h3>
    <div class="row">
      <Vault v-for="Vault in userVaults" :key="Vault.id" :vaultData="Vault" />
    </div>
    <h3 class="text-center">My Keeps</h3>
    <div class="row">
      <Keep v-for="Keep in userKeeps" :key="Keep.id" :keepData="Keep" />
    </div>
  </div>
</template>

<script>
import Vault from "../components/Vault";
import Keep from "../components/Keep";
export default {
  name: "Dashboard",
  mounted() {
    this.$store.dispatch("getUserKeeps");
  },
  computed: {
    userVaults() {
      return this.$store.state.userVaults;
    },
    userKeeps() {
      return this.$store.state.userKeeps;
    }
  },
  components: {
    Vault,
    Keep
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
