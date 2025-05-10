import { useEffect, useState } from "react";
import { observer } from "mobx-react-lite";
import vehicleMakeStore from "../stores/vehicleMakeStore";
import type { VehicleMake } from "../models/vehicleMake";
import { Button, styled, TextField, Typography } from "@mui/material";

const Root = styled("div")(() => ({
  display: "flex",
  flexDirection: "column",
  gap: "1rem",
  width: "34.75rem",
}));

const ListContainer = styled("div")(() => ({
  backgroundColor: "#092E49",
  color: "#fff",
  display: "flex",
  justifyContent: "space-between",
  alignItems: "center",
  padding: "0.625rem 0.75rem",
  borderRadius: "0.5rem",
}));

const TextFieldContainer = styled("div")(() => ({
  display: "flex",
  gap: "1.5rem",
  marginRight: "1rem",
}));

const ButtonContainer = styled("div")(() => ({
  display: "flex",
  gap: "0.5rem",
}));

const PagingContainer = styled("div")(() => ({
  display: "flex",
  justifyContent: "center",
  gap: "1.5rem",
}));

const VehicleMakeList = () => {
  const [editId, setEditId] = useState<number | null>(null);
  const [form, setForm] = useState({ name: "", abrv: "" });

  useEffect(() => {
    vehicleMakeStore.loadVehicleMakes();
  }, []);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const startEdit = (make: VehicleMake) => {
    setEditId(make.id);
    setForm({ name: make.name, abrv: make.abrv });
  };

  const cancelEdit = () => {
    setEditId(null);
    setForm({ name: "", abrv: "" });
  };

  const saveEdit = () => {
    if (editId !== null) {
      vehicleMakeStore.updateVehicleMake({ id: editId, ...form });
      cancelEdit();
    }
  };

  if (vehicleMakeStore.loading) return <p>Loading...</p>;

  return (
    <Root>
      {vehicleMakeStore.vehicleMakes.map((make) => (
        <ListContainer key={make.id}>
          {editId === make.id ? (
            <>
              <TextFieldContainer>
                <TextField
                  sx={{
                    width: "100%",
                    backgroundColor: "#092E49",
                    border: "2px solid #5798C7",
                    borderRadius: "0.5rem",
                    input: {
                      color: "#fff",
                      fontSize: "0.875rem",
                      lineHeight: "1.125rem",
                      padding: "0.5rem 0.5rem 0.5rem 1rem",
                    },
                    "& .MuiOutlinedInput-notchedOutline": {
                      border: "none",
                    },
                    "&:focus-within .MuiOutlinedInput-notchedOutline": {
                      border: "none",
                    },
                  }}
                  name="name"
                  value={form.name}
                  onChange={handleChange}
                />
                <TextField
                  sx={{
                    width: "100%",
                    backgroundColor: "#092E49",
                    border: "2px solid #5798C7",
                    borderRadius: "0.5rem",
                    input: {
                      color: "#fff",
                      fontSize: "0.875rem",
                      lineHeight: "1.125rem",
                      padding: "0.5rem 0.5rem 0.5rem 1rem",
                    },
                    "& .MuiOutlinedInput-notchedOutline": {
                      border: "none",
                    },
                    "&:focus-within .MuiOutlinedInput-notchedOutline": {
                      border: "none",
                    },
                  }}
                  name="abrv"
                  value={form.abrv}
                  onChange={handleChange}
                />
              </TextFieldContainer>
              <ButtonContainer>
                <Button
                  sx={{
                    backgroundColor: "#275B80",
                    color: "#fff",
                    fontSize: "0.75rem",
                    fontWeight: "500",
                    letterSpacing: "5%",
                    lineHeight: "1rem",
                    textTransform: "capitalize",
                    padding: "0.5rem 0.75rem",
                    borderRadius: "0.5rem",
                    "&:hover": {
                      backgroundColor: "#5798C7",
                    },
                    "&:active": {
                      backgroundColor: "#7DAFD3",
                    },
                  }}
                  onClick={saveEdit}
                >
                  Save
                </Button>
                <Button
                  sx={{
                    backgroundColor: "#275B80",
                    color: "#fff",
                    fontSize: "0.75rem",
                    fontWeight: "500",
                    letterSpacing: "5%",
                    lineHeight: "1rem",
                    textTransform: "capitalize",
                    padding: "0.5rem 0.75rem",
                    borderRadius: "0.5rem",
                    "&:hover": {
                      backgroundColor: "#5798C7",
                    },
                    "&:active": {
                      backgroundColor: "#7DAFD3",
                    },
                  }}
                  onClick={cancelEdit}
                >
                  Cancel
                </Button>
              </ButtonContainer>
            </>
          ) : (
            <>
              <Typography>
                {make.name} - {make.abrv.toUpperCase()}
              </Typography>
              <ButtonContainer>
                <Button
                  sx={{
                    backgroundColor: "#275B80",
                    color: "#fff",
                    fontSize: "0.75rem",
                    fontWeight: "500",
                    letterSpacing: "5%",
                    lineHeight: "1rem",
                    textTransform: "capitalize",
                    padding: "0.5rem 0.75rem",
                    borderRadius: "0.5rem",
                    "&:hover": {
                      backgroundColor: "#5798C7",
                    },
                    "&:active": {
                      backgroundColor: "#7DAFD3",
                    },
                  }}
                  onClick={() => startEdit(make)}
                >
                  Edit
                </Button>
                <Button
                  sx={{
                    backgroundColor: "#275B80",
                    color: "#fff",
                    fontSize: "0.75rem",
                    fontWeight: "500",
                    letterSpacing: "5%",
                    lineHeight: "1rem",
                    textTransform: "capitalize",
                    padding: "0.5rem 0.75rem",
                    borderRadius: "0.5rem",
                    "&:hover": {
                      backgroundColor: "#5798C7",
                    },
                    "&:active": {
                      backgroundColor: "#7DAFD3",
                    },
                  }}
                  onClick={() => vehicleMakeStore.deleteVehicleMake(make.id)}
                >
                  Delete
                </Button>
              </ButtonContainer>
            </>
          )}
        </ListContainer>
      ))}
      <PagingContainer style={{ marginTop: "1rem" }}>
        <Button
          sx={{
            backgroundColor: "#275B80",
            color: "#fff",
            fontSize: "0.75rem",
            fontWeight: "500",
            letterSpacing: "5%",
            lineHeight: "1rem",
            textTransform: "capitalize",
            padding: "0.5rem 0.75rem",
            borderRadius: "0.5rem",
            "&:hover": {
              backgroundColor: "#5798C7",
            },
            "&:active": {
              backgroundColor: "#7DAFD3",
            },
            "&.Mui-disabled": {
              backgroundColor: "rgba(39, 91, 128, 0.3)",
              color: "rgba(255, 255, 255, 0.3)",
            },
          }}
          onClick={() => vehicleMakeStore.setPage(vehicleMakeStore.page - 1)}
          disabled={vehicleMakeStore.page === 1}
        >
          Previous
        </Button>
        <Typography
          sx={{
            fontSize: "1rem",
            color: "#fff",
            letterSpacing: "5%",
            lineHeight: "2.25rem",
          }}
        >
          {vehicleMakeStore.totalPages === 0
            ? "Page 0 of 0"
            : `Page ${vehicleMakeStore.page} of ${vehicleMakeStore.totalPages}`}
        </Typography>

        <Button
          sx={{
            backgroundColor: "#275B80",
            color: "#fff",
            fontSize: "0.75rem",
            fontWeight: "500",
            letterSpacing: "5%",
            lineHeight: "1rem",
            textTransform: "capitalize",
            padding: "0.5rem 0.75rem",
            borderRadius: "0.5rem",
            "&:hover": {
              backgroundColor: "#5798C7",
            },
            "&:active": {
              backgroundColor: "#7DAFD3",
            },
            "&.Mui-disabled": {
              backgroundColor: "rgba(39, 91, 128, 0.3)",
              color: "rgba(255, 255, 255, 0.3)",
            },
          }}
          onClick={() => vehicleMakeStore.setPage(vehicleMakeStore.page + 1)}
          disabled={
            vehicleMakeStore.page === vehicleMakeStore.totalPages ||
            vehicleMakeStore.totalPages === 0
          }
        >
          Next
        </Button>
      </PagingContainer>
    </Root>
  );
};

export default observer(VehicleMakeList);
